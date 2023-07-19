using HelpTrader.Domain.Extensions;
using Tinkoff.InvestApi.V1;

namespace HelpTrader.Services.Analysis;

/// <summary>
/// Initial for --<inheritdoc cref="IMovingAverage"/> 
/// </summary>
public class MovingAverage : IMovingAverage
{
    private const int Precision = 2;

    /// <inheritdoc />
    public async Task<List<decimal>> GetEmaAsync(List<Quotation> priceList, int smoothingPeriod, List<decimal> result)
    {
        result.Add((decimal)0.0);
        var smoothingFactor = 2.0d / (1.0d + smoothingPeriod);
        var coefficient = 1d - (smoothingFactor);

        for (var i = 1; i < priceList.Count - 1; i++)
        {
            var ema = (priceList[i] * (decimal)smoothingFactor) + result[i-1] * (decimal)coefficient;
            ema = ema.RoundToPrecision(Precision);
            result.Add(ema);
        }

        return result;
    }
}