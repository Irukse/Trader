using HelpTrader.Models;
using Microsoft.Extensions.Caching.StackExchangeRedis;
namespace HelpTrader.Services.Application.Manager.Repository;

    public interface IBasketRepository
    {
        Task<ShareData> GetBasket(string userName);
        Task UpdateBasket(ShareData  basket);
        Task DeleteBasket(string userName);
    }
