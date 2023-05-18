namespace HelpTrader.Models;

public class DataAnalysisShare 
                      
{
    public string Name{ get; set; }

    public decimal Price { get; set; }
    
    //  public string Figi { get; set; }
    
    /// <summary>
    /// Fair value of a share
    /// </summary>
    public decimal? FairPrice { get; set; }
}