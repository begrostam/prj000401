using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using prj_asp_net_core_react.Entities;
using prj_asp_net_core_react.config;


namespace prj_asp_net_core_react.Services.UserServices
{
    public class UserService:IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User{
            Id =1,FirstName ="محمد",LastName="بیکی",UserName="a",Password="a",Role="agent"

        },
        new User{
            Id =2,FirstName ="3علی",LastName="مقدم",UserName="b",Password="b",Role="admin"
        }
        };

private readonly AppSettings _appSettings;

public UserService (IOptions< AppSettings> appSettings)
{
    _appSettings = appSettings.Value;
}
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User Authenticate(string username,string password)
        {
            var user = _users.SingleOrDefault(x=>x.UserName== username && x.Password == password);
            
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaims(new[]
            {
                new Claim(ClaimTypes.Role, user.Role.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
                
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}