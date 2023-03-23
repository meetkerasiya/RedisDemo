using APIwithRedis.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace APIwithRedis.CacheService
{
    public class CacheService<TCacheValue> : ICacheService<TCacheValue>
    {
        private readonly ILogger<CacheService<TCacheValue>> _logger;
        private readonly IDistributedCache _distributedCache;
        private readonly string _key = "RedisKey";

        public CacheService(ILogger<CacheService<TCacheValue>> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
            

        }

        public async Task<TCacheValue> GetValueAsync(string key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            try
            {
                var value = await GetValuesAsync(key);
                return string.IsNullOrEmpty(value) ? default : JsonSerializer.Deserialize<TCacheValue>(value);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "failed to load from redis");
            }
            return default(TCacheValue);
        }

        private async Task<string> GetValuesAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task SetValueAsync(string key, TCacheValue value)
        {
            try
            {
                var valueString = JsonSerializer.Serialize(value);
                var distributedCacheEntryOptions = new DistributedCacheEntryOptions
                {
                    //AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };
                await _distributedCache.SetStringAsync(key, valueString /*, distributedCacheEntryOptions*/);
            }
            catch(Exception ex) 
            {
                _logger.LogWarning(ex, "failed to load data to redis");
            }
        }

      
    }

}
