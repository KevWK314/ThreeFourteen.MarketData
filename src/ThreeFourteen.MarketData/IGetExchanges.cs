using ThreeFourteen.MarketData.Model;

namespace ThreeFourteen.MarketData;

public interface IGetExchanges
{
    Task<IEnumerable<Exchange>> GetExchanges();
}
