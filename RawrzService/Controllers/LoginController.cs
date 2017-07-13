using RawrzMe.Library.Models;
using System.Web.Http;

namespace RawrzService.Controllers
{
    public class LoginController : ApiController
    {
        public User Post(Login loginModel)
        {
            return new User();
        }
    }
}
