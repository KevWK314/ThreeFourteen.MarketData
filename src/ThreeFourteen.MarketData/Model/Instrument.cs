namespace ThreeFourteen.MarketData.Model;

public record Instrument
{
    public string Name { get; init; }
    public string Ticker { get; init; }
    public string SourceSymbol { get; init; }
}