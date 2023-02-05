namespace ThreeFourteen.MarketData.MarketStack;

public record MarketStackClientConfig
{
    public Uri BaseAddress { get; init; } = new Uri("https://api.marketstack.com");
    public string AccessToken { get; init; }
    public int RequestLimit { get; init; } = 1000;
}
