namespace ThreeFourteen.MarketData.MarketStack.Model;

public record MarketStackExchangeTickers
{
    public string Name { get; init; }
    public string Acronym { get; init; }
    public string Mic { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public IEnumerable<MarketStackInstrument> Tickers { get; init; }
}
