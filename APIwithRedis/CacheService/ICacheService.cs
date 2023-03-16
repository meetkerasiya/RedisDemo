namespace APIwithRedis.CacheService
{
    public interface ICacheService<TCacheValue>
    {
        Task<TCacheValue> GetValueAsync(string key);
        Task SetValueAsync(string key, TCacheValue value);
    }
}