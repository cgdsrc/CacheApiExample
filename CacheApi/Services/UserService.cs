using System;
using System.Net.Http;
using CahceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace CahceAPI.Services
{
    public class UserService : IUserService
    {

        private const string CACHE_KEY = "User-Cache";
        private readonly ICacheService _cacheService;

        public UserService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<List<Users>> GetUsers()
        {

            List<Users> users = new List<Users>();

            users = _cacheService.GetCacheUsers(CACHE_KEY);

            if (users.Count == 0)
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
                };

                client.DefaultRequestHeaders.Accept.Clear();
                var responseTask = await client.GetAsync("/users");
                var readTask = responseTask.Content.ReadAsStringAsync();
                var user = readTask.Result;
                if (!string.IsNullOrEmpty(user))
                {
                    users = JsonConvert.DeserializeObject<List<Users>>(user);
                    _cacheService.AddToCache(users);
                }
            }
            return users;
        }
    }
}
