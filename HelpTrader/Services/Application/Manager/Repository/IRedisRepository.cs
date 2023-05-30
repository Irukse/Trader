namespace HelpTrader.Services.Application.Manager.Repository;

    public interface IRedisRepository
    {
        Task<object> GetBasket<T>(string userName);
        
        public Task UpdateBasket<T>(string key, T share);
        
        Task DeleteBasket(string share);
    }
