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
                FirstName = "Wendy",
                LastName = "Crawford",
                Email = "wendy.crawford@fakemail.com",
                Phone = "5739794672",
                CanEmail = true,
                CanText = true
            };
        }
    }
}
