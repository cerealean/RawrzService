using System;
using RawrzMe.Library.Daos;
using RawrzMe.Library.Models;

namespace RawrzMe.Library.Services
{
    public class Login : IDisposable
    {
        private readonly UserDao _userDao = new UserDao();

        public Models.User AttemptLogin(Models.Login loginModel)
        {
            return _userDao.GetUserByUsername(loginModel.Username);
        }

        public void Dispose()
        {
            _userDao?.Dispose();
        }
    }
}
