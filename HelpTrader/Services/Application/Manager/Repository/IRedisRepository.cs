using HelpTrader.Models;
namespace HelpTrader.Services.Application.Manager.Repository;

    public interface IRedisRepository
    {
        Task<object> GetBasket<T>(string userName);
        Task UpdateBasket(object basket);
        Task DeleteBasket(string share);
    }
