using System.Threading;
using System.Web.Http;
using RawrzService.Models;

namespace RawrzService.Controllers
{
    public class LogoutController : ApiController
    {
        public void Post(User user)
        {
            Thread.Sleep(1000);
        }
    }
}
