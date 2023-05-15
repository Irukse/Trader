using SimulatorBroker.Models;

namespace SimulatorBroker.Service;

public class BrokerService : IBrokerService
{
    private Random _price = new Random();
    
    public BrokerService()
    {
        
    }

    public BrokerData GetBrokerData()
    {
        var price = new decimal(_price.Next(10, 15));
        var brokerData = new BrokerData()
        {
            Share = "Ford",
            Price = price,
        };
        
        return brokerData;
    }
    
    public BrokerData GetBrokerData(string share)
    {
        var price = new decimal(_price.Next(10, 15));

        if (share.Equals("Ford"))
        {
            var brokerData = new BrokerData()
            {
                Share = "Ford",
                Price = price,
            };
        
            return brokerData;
        }
        
        else if (share.Equals("Lada"))
        {
            var brokerData = new BrokerData()
            {
                Share = "Lada",
                Price = price,
            };
        
            return brokerData;
        }

        return null;
    }
}