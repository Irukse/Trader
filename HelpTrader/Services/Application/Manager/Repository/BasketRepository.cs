using HelpTrader.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HelpTrader.Services.Application.Manager.Repository;

    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public async Task<ShareData> GetBasket(string name)
        {
            var basket = await _redisCache.GetStringAsync(name);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShareData>(basket);
        }
         
        public async Task UpdateBasket(ShareData share)
        {
            await _redisCache.SetStringAsync(share.Figi, JsonConvert.SerializeObject(share));
            await _redisCache.SetStringAsync(share.NameShare, JsonConvert.SerializeObject(share));

        }
        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
