using RawrzMe.Library.Mapper;
using System.Linq;

namespace RawrzMe.Library.Daos
{
    internal class UserDao
    {
        private readonly RawrzMeEntities _rawrzMeEntities = new RawrzMeEntities();

        internal Models.User GetUserByUsername(string username)
        {
            return _rawrzMeEntities.Users.FirstOrDefault(user => user.username == username)?.ToUserModel();
        }
    }
}
