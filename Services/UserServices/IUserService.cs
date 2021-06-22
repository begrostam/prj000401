using System.Collections.Generic;
using prj_asp_net_core_react.Entities;

namespace prj_asp_net_core_react.Services.UserServices
{
    public interface IUserService
    {
         User Authenticate(string username,string password);
         IEnumerable<User> GetAll();
    }
}