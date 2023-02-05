﻿namespace ThreeFourteen.MarketData.Model;

public record HistoricalDayPrice
{
    public DateOnly Date { get; init; }

    public decimal? Open { get; init; }
    public decimal? High { get; init; }
    public decimal? Low { get; init; }
    public decimal? Close { get; init; }
    public double Volume { get; init; }
}
