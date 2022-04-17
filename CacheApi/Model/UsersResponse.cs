using System;
using System.Collections.Generic;
using CahceAPI;

namespace CacheApi.Model
{
    public class UsersResponse
    {
       public List<Users> Users { get; set; }
       public bool IsCacheResponse { get; set; }
       public bool IsSuccess { get; set; }
      
    }
}
