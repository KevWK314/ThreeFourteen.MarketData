using System.Net.Http.Json;
using ThreeFourteen.MarketData.MarketStack.Model;
using ThreeFourteen.MarketData.Model;

namespace ThreeFourteen.MarketData.MarketStack;

public interface IMarketStackClient :
    IGetExchanges,
    IGetExchangeTickers,
    IGetDailyPrices
{
}

public class MarketStackClient : IMarketStackClient
{
    private readonly HttpClient _httpClient;
    private readonly MarketStackClientConfig _config;

    public MarketStackClient(HttpClient httpClient, MarketStackClientConfig config)
    {
        _httpClient = httpClient;
        _config = config;

        if (_httpClient.BaseAddress == null)
            _httpClient.BaseAddress = _config.BaseAddress;
    }

    public async Task<IEnumerable<Exchange>> GetExchanges()
    {
        var exchanges = await Get<MarketStackExchange[], MarketStackExchange>("v1/exchanges", x => x);
        return exchanges.Select(x =>
            new Exchange
            {
                Name = x.Name,
                Mic = x.Mic,
                CountryCode = x.CountryCode,
                City = x.City,
                ShortName = x.Acronym,
                SourceSymbol = x.Mic
            });
    }

    public async Task<IEnumerable<Instrument>> GetExchangeTickers(string exchangeSourceSymbol)
    {
        var exchanges = await Get<MarketStackExchangeTickers, MarketStackInstrument>(
            $"v1/exchanges/{exchangeSourceSymbol}/tickers",
            x => x.Tickers);
        return exchanges.Select(x =>
            new Instrument
            {
                Name = x.Name,
                Ticker = x.Symbol,
                SourceSymbol = x.Symbol
            });
    }

    public Task<IEnumerable<HistoricalDayPrice>> GetDailyPrices(string tickerSourceSymbol, DateOnly from)
    {
        throw new NotImplementedException();
    }

    private async Task<IEnumerable<TData>> Get<TResponse, TData>(string uri, Func<TResponse, IEnumerable<TData>> getData)
    {
        var data = new List<TData>();
        await foreach (var response in Request<TResponse>(uri))
        {
            data.AddRange(getData(response.Data));
        }

        return data;
    }

    private async IAsyncEnumerable<MarketDataResponse<TData>> Request<TData>(string uri)
    {
        var offset = 0;
        while (offset >= 0)
        {
            var fullUri = $"{uri}?access_key={_config.AccessToken}&offset={offset}&limit={_config.RequestLimit}";
            using var response = await _httpClient.GetAsync(fullUri);
            await ValidateResponse(response);

            var marketDataResponse = await response.Content.ReadFromJsonAsync<MarketDataResponse<TData>>();
            yield return marketDataResponse;

            offset += _config.RequestLimit;
            if (offset >= marketDataResponse.Pagination.Total)
                break;
        }
    }

    private static async Task ValidateResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var error = await response.Content.ReadFromJsonAsync<MarketStackError>();
        throw new MarketStackException(error);
    }
}
