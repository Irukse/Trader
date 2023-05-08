namespace SimulatorBroker.Models;

public class BrokerData
{
    public string Share { get; set; }
    
    public decimal Price { get; set; }
    
    public DateTime RequestDate { get; } = DateTime.Now;
}