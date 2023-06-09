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
    
    public List<string> GetListDataShares(string share)
    {
        
        var figiFord = "FIGIFORD";
        var figiLada = "FIGILADA";

        if (share.Equals("Ford"))
        {
            var brokerData = new List<string>()
            {
                 "Ford",
                 figiFord,
            };
        
            return brokerData;
        }
        
        else if (share.Equals("Lada"))
        {
            var brokerData = new List<string>()
            {
                "Lada",
                figiLada,
            };
        
            return brokerData;
        }

        return null;
    }

    public List<object> GetPrice(string figi)
    {
        var priceF = new decimal(_price.Next(10, 15));
        var priceFFFF =  0.39999999999999997M;
        var priceL = new decimal(_price.Next(20, 25));
        
        
        if (figi.Equals("FIGIFORD"))
        {
            var brokerData = new List<object>()
            {
                figi,
                priceFFFF
            };
        
            return brokerData;
        }
        if (figi.Equals("FIGILADA"))
        {
            var brokerData = new List<object>()
            {
                figi,
                priceL
            };
        
            return brokerData;
        }

        return null;
    }
}