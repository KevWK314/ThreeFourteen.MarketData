using ThreeFourteen.MarketData.Model;

namespace ThreeFourteen.MarketData;

public interface IGetDailyPrices
{
    Task<IEnumerable<HistoricalDayPrice>> GetDailyPrices(string tickerSourceSymbol, DateOnly from);
}