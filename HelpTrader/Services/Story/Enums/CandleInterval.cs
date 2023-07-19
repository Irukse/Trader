namespace HelpTrader.Services.Story.Enums;

/// <summary>
/// Candle interval
/// </summary>
public enum CandleInterval
{
    /// <summary>
    /// Interval not defined.
    /// </summary>
    CANDLE_INTERVAL_UNSPECIFIED = Tinkoff.InvestApi.V1.CandleInterval.Unspecified,

    /// <summary>
    /// from 1 minute to 1 day.
    /// </summary>
    CANDLE_INTERVAL_1_MIN = Tinkoff.InvestApi.V1.CandleInterval._1Min,

    /// <summary>
    /// from 5 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_5_MIN = Tinkoff.InvestApi.V1.CandleInterval._5Min,

    /// <summary>
    /// from 15 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_15_MIN = Tinkoff.InvestApi.V1.CandleInterval._15Min,

    /// <summary>
    /// from 1 hour to 1 week.
    /// </summary>
    CANDLE_INTERVAL_HOUR = Tinkoff.InvestApi.V1.CandleInterval.Hour,

    /// <summary>
    /// from 1 day to 1 year.
    /// </summary>
    CANDLE_INTERVAL_DAY = Tinkoff.InvestApi.V1.CandleInterval.Day,

    /// <summary>
    /// from 2 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_2_MIN = Tinkoff.InvestApi.V1.CandleInterval._2Min,

    /// <summary>
    /// from 3 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_3_MIN = Tinkoff.InvestApi.V1.CandleInterval._3Min,

    /// <summary>
    /// from 10 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_10_MIN = Tinkoff.InvestApi.V1.CandleInterval._10Min,

    /// <summary>
    /// from 30 minutes to 2 days.
    /// </summary>
    CANDLE_INTERVAL_30_MIN = Tinkoff.InvestApi.V1.CandleInterval._30Min,

    /// <summary>
    /// from 2 hours to 1 month.
    /// </summary>
    CANDLE_INTERVAL_2_HOUR = Tinkoff.InvestApi.V1.CandleInterval._2Hour,

    /// <summary>
    /// from 4 hours to 1 month.
    /// </summary>
    CANDLE_INTERVAL_4_HOUR = Tinkoff.InvestApi.V1.CandleInterval._4Hour,

    /// <summary>
    /// from 1 week to 2 years.
    /// </summary>
    CANDLE_INTERVAL_WEEK = Tinkoff.InvestApi.V1.CandleInterval.Week,

    /// <summary>
    /// from 1 month to 10 years.
    /// </summary>
    CANDLE_INTERVAL_MONTH = Tinkoff.InvestApi.V1.CandleInterval.Month,
}