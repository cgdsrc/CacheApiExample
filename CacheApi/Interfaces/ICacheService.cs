using System.Collections.Generic;

namespace CahceAPI.Services
{
    public interface ICacheService
    {
        List<Users> GetCacheUsers(string Key);
        void AddToCache(List<Users> Users);
    }
}
