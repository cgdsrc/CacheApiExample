using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace CahceAPI.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<Users> GetCacheUsers(string Key)
        {
            List<Users> users = new List<Users>();

            if (!IsCacheNull(Key))
            {
                users = (List<Users>)_memoryCache.Get(Key);
            }

            return users;
        }

        public void AddToCache(List<Users> User)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            _memoryCache.Set("User-Cache", User, cacheEntryOptions);
        }

        private bool IsCacheNull(string Key)
        {
            if (_memoryCache.TryGetValue(Key, out List<Users> cacheValue))
            {
                return false;
            }

            return true;
        }
    }
}
