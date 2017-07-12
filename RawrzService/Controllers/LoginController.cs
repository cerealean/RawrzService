using System;
using System.Web.Http;
using RawrzService.Models;

namespace RawrzService.Controllers
{
    public class LoginController : ApiController
    {
        public User Post(Login loginModel)
        {
            return new User
            {
                Id = 55,
                Username = "Cerealean",
                FirstName = "Wendy",
                LastName = "Crawford",
                Email = "wendy.crawford@fakemail.com",
                Phone = "5739794672",
                CanEmail = true,
                CanText = true,
                TwoFactorAuthentication = true,
                Authentication = new Authentication
                {
                    Expires = DateTime.Now.AddDays(3),
                    LoggedIn = DateTime.Now,
                    Token = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
