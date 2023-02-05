using System.Text.Json.Serialization;

namespace ThreeFourteen.MarketData.MarketStack.Model;

public record MarketStackExchange
{
    public string Name { get; init; }
    public string Acronym { get; init; }
    public string Mic { get; init; }
    public string Country { get; init; }
    [JsonPropertyName("country_code")]
    public string CountryCode { get; init; }
    public string City { get; init; }
}
