using ThreeFourteen.MarketData.MarketStack.Model;

namespace ThreeFourteen.MarketData.MarketStack;

public class MarketStackException : Exception
{
	public MarketStackException(MarketStackError marketStackError)
        : base($"{marketStackError.Code} - {marketStackError.Message}")
	{
        MarketStackError = marketStackError;
    }

    public MarketStackError MarketStackError { get; }
}
