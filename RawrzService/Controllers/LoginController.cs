using System.Net;
using System.Net.Http;
using RawrzMe.Library.Models;
using System.Web.Http;

namespace RawrzService.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Post(Login loginModel)
        {
            var user = new RawrzMe.Library.Services.Login().AttemptLogin(loginModel);
            var isUserFound = user != null && user.Id != 0;
            var responseStatusCode = isUserFound ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
            return Request.CreateResponse(responseStatusCode, user);
        }
    }
}
