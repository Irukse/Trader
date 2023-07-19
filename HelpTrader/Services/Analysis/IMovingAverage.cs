using Tinkoff.InvestApi.V1;

namespace HelpTrader.Services.Analysis;

public interface IMovingAverage
{
    /// <summary>
    /// EMA = price(t) * k + EMA(y) * (1 – k)
    /// t = now(today).
    /// y = previous period (yesterday)
    /// k = smoothing factor in the EMA. 2 ÷ (N + 1).
    /// N = smoothing period (depending on the choice of the period of the candle (day, min))
    /// </summary>
    /// <param name="priceList"></param>
    /// <param name="smoothingPeriod"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public Task<List<decimal>> GetEmaAsync(List<Quotation> priceList, int smoothingPeriod, List<decimal> result);
}