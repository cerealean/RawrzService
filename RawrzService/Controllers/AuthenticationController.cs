using System.Net;
using System.Net.Http;
using System.Web.Http;
using RawrzMe.Library.Models;

namespace RawrzService.Controllers
{
    public class AuthenticationController : ApiController
    {
        public HttpResponseMessage Post(NewUser newUser)
        {
            using (var authentication = new RawrzMe.Library.Services.Authentication())
            {
                HttpStatusCode responseCode;

                if (authentication.DoesUsernameCurrentlyExist(newUser.Username))
                {
                    responseCode = HttpStatusCode.Conflict;
                }
                else
                {
                    authentication.CreateNewUser(newUser);
                    responseCode = HttpStatusCode.NoContent;
                }

                return Request.CreateResponse(responseCode);
            }
        }

        public HttpResponseMessage Put(PasswordChange passwordChange)
        {
            using (var authentication = new RawrzMe.Library.Services.Authentication())
            {
                HttpStatusCode responseCode;

                if (authentication.AreUserCredentialsValid(passwordChange.Username, passwordChange.OldPassword))
                {
                    authentication.UpdatePassword(passwordChange);
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
