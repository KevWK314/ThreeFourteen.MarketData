using System.Text.Json.Serialization;

namespace ThreeFourteen.MarketData.MarketStack.Model;

public record MarketStackInstrument
{
    public string Name { get; init; }
    public string Symbol { get; init; }
    [JsonPropertyName("has_intraday")]
    public bool HasIntraday { get; init; }
    [JsonPropertyName("has_eod")]
    public bool HasEod { get; init; }
}