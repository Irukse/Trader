namespace HelpTrader.Domain.Extensions;

public static class DecimalExtensions
{
    /// <summary>
    /// Precision
    /// </summary>
    /// <param name="number"></param>
    /// <param name="precision"></param>
    /// <returns></returns>
    public static decimal RoundToPrecision(this decimal number, int precision)
    {
       return Math.Round(number, precision);
    } 
}