using System;
using RawrzMe.Library.Daos;

namespace RawrzMe.Library.Services
{
    public class User : IDisposable
    {
        private readonly UserDao _userDao = new UserDao();

        public void UpdateUser(Models.User user)
        {
            _userDao.UpdateUser(user);
        }

        public void Dispose()
        {
            _userDao?.Dispose();
        }
    }
}
