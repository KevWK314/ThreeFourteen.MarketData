using ThreeFourteen.MarketData.MarketStack.Model;

namespace ThreeFourteen.MarketData.MarketStack;

public record MarketDataResponse<TData>
{
    public MarketDataResponsePagination Pagination { get; init; }
    public TData Data { get; init; }
}
