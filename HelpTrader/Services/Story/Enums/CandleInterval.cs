namespace HelpTrader.Services.Story.Enums;

/// <summary>
/// Candle interval
/// </summary>
public enum CandleInterval
{
    /// <summary>
    /// Interval not defined.
    /// </summary>
    CANDLE_INTERVAL_UNSPECIFIED = 0,

    /// <summary>
    /// from 1 minute to 1 day.
    /// </summary>
    CANDLE_INTERVAL_1_MIN = 1,

    /// <summary>
    /// from 5 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_5_MIN = 2,

    /// <summary>
    /// from 15 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_15_MIN = 3,

    /// <summary>
    /// from 1 hour to 1 week.
    /// </summary>
    CANDLE_INTERVAL_HOUR = 4,

    /// <summary>
    /// from 1 day to 1 year.
    /// </summary>
    CANDLE_INTERVAL_DAY = 5,

    /// <summary>
    /// from 2 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_2_MIN = 6,

    /// <summary>
    /// from 3 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_3_MIN = 7,

    /// <summary>
    /// from 10 minutes to 1 day.
    /// </summary>
    CANDLE_INTERVAL_10_MIN = 8,

    /// <summary>
    /// from 30 minutes to 2 days.
    /// </summary>
    CANDLE_INTERVAL_30_MIN = 9,

    /// <summary>
    /// from 2 hours to 1 month.
    /// </summary>
    CANDLE_INTERVAL_2_HOUR = 10,

    /// <summary>
    /// from 4 hours to 1 month.
    /// </summary>
    CANDLE_INTERVAL_4_HOUR = 11,

    /// <summary>
    /// from 1 week to 2 years.
    /// </summary>
    CANDLE_INTERVAL_WEEK = 12,

    /// <summary>
    /// from 1 month to 10 years.
    /// </summary>
    CANDLE_INTERVAL_MONTH = 13,
}