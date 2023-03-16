using APIwithRedis.Models;

namespace APIwithRedis.CacheSetup
{
    public interface ICacheSetup
    {
        Task LoadData();
    }
}