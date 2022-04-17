using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CahceAPI.Services
{
    public interface IUserService
    {
        Task<List<Users>> GetUsers();
    }
}
