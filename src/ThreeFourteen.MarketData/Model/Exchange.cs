namespace ThreeFourteen.MarketData.Model;

public record Exchange
{
    public string Name { get; init; }
    public string Mic { get; init; }
    public string ShortName { get; init; }
    public string CountryCode { get; init; }
    public string City { get; init; }
    public string SourceSymbol { get; init; }
}