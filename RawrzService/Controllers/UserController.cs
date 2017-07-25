using System.Net;
using System.Net.Http;
using System.Web.Http;
using RawrzMe.Library.Exceptions;
using RawrzMe.Library.Models;

namespace RawrzService.Controllers
{
    public class UserController : ApiController
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

        public HttpResponseMessage Put(User user)
        {
            using (var userService = new RawrzMe.Library.Services.User())
            {
                try
                {
                    userService.UpdateUser(user);
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch (UserNotFoundException)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
