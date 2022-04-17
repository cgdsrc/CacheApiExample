using System.Collections.Generic;
using System.Threading.Tasks;
using CacheApi.Model;
using CahceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CahceAPI.Controller
{

    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        private readonly IUserService _userService;

        public APIController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<UsersResponse> GetUsersAsync()
        {
            List<Users> users = await _userService.GetUsers();

            if (users.Count > 0)
            {
                return new UsersResponse
                {
                    Users = users,
                    IsSuccess = true
                };
            }

            return new UsersResponse { IsSuccess = false };
        }

    }
}