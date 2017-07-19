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
            return _rawrzMeEntities.users.FirstOrDefault(user => user.username == username)?.ToUserModel();
        }

        internal Models.UserAuthentication GetUserAuthenticationByUsername(string username)
        {
            return _rawrzMeEntities.users
                .FirstOrDefault(user => user.username == username)
                ?.user_authentication
                ?.FirstOrDefault()
                ?.ToUserAuthentication();
        }

        internal void UpdateUserAuthentication(Models.UserAuthentication userAuthentication)
        {
            var userAuthEntity = _rawrzMeEntities.user_authentication.First(ua => ua.id == userAuthentication.Id);
            userAuthEntity.salt = userAuthentication.Salt;
            userAuthEntity.hash = userAuthentication.Hash;
            _rawrzMeEntities.SaveChanges();
        }

        internal void CreateUserAuthentication(Models.UserAuthentication userAuthentication)
        {
            var newUserAuthEntity = new user_authentication
            {
                salt = userAuthentication.Salt,
                hash = userAuthentication.Hash,
                user_id = userAuthentication.UserId
            };
            _rawrzMeEntities.user_authentication.Add(newUserAuthEntity);
            _rawrzMeEntities.SaveChanges();
        }

        public void Dispose()
        {
            _rawrzMeEntities?.Dispose();
        }
    }
}
