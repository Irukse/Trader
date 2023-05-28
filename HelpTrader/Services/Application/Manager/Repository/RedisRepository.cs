using HelpTrader.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HelpTrader.Services.Application.Manager.Repository;

    public class RedisRepository : IRedisRepository
    {
        private readonly IDistributedCache _redisCache;
        public RedisRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public async Task<object> GetBasket<T>(string name)
        {
            var basket = await _redisCache.GetStringAsync(name);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<T>(basket);
        }

        // public async Task UpdateBasket(ShareData share)
        // {
        //     await _redisCache.SetStringAsync(share.Figi, JsonConvert.SerializeObject(share));
        //     await _redisCache.SetStringAsync(share.Ticker, JsonConvert.SerializeObject(share));
        // }
        
        public async Task UpdateBasket(object share)
        {
            await _redisCache.SetStringAsync(share.ToString(), JsonConvert.SerializeObject(share));
       
        }
        public async Task DeleteBasket(string share)
        {
            await _redisCache.RemoveAsync(share);
        }
    }
