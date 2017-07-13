using RawrzMe.Library.Mapper;
using System;
using System.Linq;

namespace RawrzMe.Library.Daos
{
    internal class UserDao : IDisposable
    {
        private readonly RawrzMeEntities _rawrzMeEntities = new RawrzMeEntities();

        internal Models.User GetUserByUsername(string username)
        {
            return _rawrzMeEntities.Users.FirstOrDefault(user => user.username == username)?.ToUserModel();
        }

        public void Dispose()
        {
            _rawrzMeEntities?.Dispose();
        }
    }
}
