using ThreeFourteen.MarketData.Model;

namespace ThreeFourteen.MarketData;

public interface IGetExchangeTickers
{
    Task<IEnumerable<Instrument>> GetExchangeTickers(string exchangeSourceSymbol);
}