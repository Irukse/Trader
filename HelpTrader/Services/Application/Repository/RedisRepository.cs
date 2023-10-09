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
        
        public async Task UpdateBasket<T>(string key, T share)
        {
            await _redisCache.SetStringAsync( key,
                JsonConvert.SerializeObject(share),
                new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddSeconds(60)});
        }
        public async Task DeleteBasket(string share)
        {
            await _redisCache.RemoveAsync(share);
        }
    }
