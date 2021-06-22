using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prj_asp_net_core_react.DtoModels;
using Microsoft.AspNetCore.Authorization;
using prj_asp_net_core_react.Services.UserServices;
using prj_asp_net_core_react.Entities;

namespace prj_asp_net_core_react.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IUserService _UserService ;

        public UserController (IUserService UserService)
        {
           _UserService = UserService;
        }
        [HttpGet("login")]
        public User Login()
        {
           var User = _UserService.Authenticate("a","a");
           return  User;

        }
        [Authorize(Roles  = "agent")]
        [HttpGet("hello")]
        public IActionResult hello()
        {
          
           return Content("hello");

        }

        [HttpGet("hello1")]
        public IActionResult hello1()
        {
          
           return Content("hello1");

        }
    }
}