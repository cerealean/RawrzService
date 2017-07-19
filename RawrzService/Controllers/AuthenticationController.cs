using System.Net;
using System.Net.Http;
using System.Web.Http;
using RawrzMe.Library.Models;

namespace RawrzService.Controllers
{
    public class AuthenticationController : ApiController
    {
        public HttpResponseMessage Put(Login loginModel)
        {
            using (var authentication = new RawrzMe.Library.Services.Authentication())
            {
                HttpStatusCode responseCode;

                if (authentication.IsPasswordValid(loginModel))
                {
                    authentication.UpdatePassword(loginModel);
                    responseCode = HttpStatusCode.NoContent;
                }
                else
                {
                    responseCode = HttpStatusCode.Unauthorized;
                }

                return Request.CreateResponse(responseCode);
            }
        }
    }
}
