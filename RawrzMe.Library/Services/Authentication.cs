using System;
using System.Text;
using RawrzMe.Library.Daos;
using RawrzMe.Library.Models;
using Sodium;

namespace RawrzMe.Library.Services
{
    public class Authentication : IDisposable
    {
        private readonly UserDao _userDao = new UserDao();
        private readonly Encoding _defaultEncoding = Encoding.UTF8;

        public bool IsPasswordValid(Models.Login loginModel)
        {
            var userAuthentication = _userDao.GetUserAuthenticationByUsername(loginModel.Username);
            var bytePassword = _defaultEncoding.GetBytes(loginModel.Password);
            return PasswordHash.ScryptHashStringVerify(userAuthentication.Hash, bytePassword);
        }

        public void UpdatePassword(Models.Login loginModel)
        {
            var userAuthentication = _userDao.GetUserAuthenticationByUsername(loginModel.Username);

            if (userAuthentication != null)
            {
                UpdateUserAuthentication(userAuthentication, loginModel.Password);
            }
            else
            {
                CreateUserAuthentication(loginModel);
            }
        }

        private void UpdateUserAuthentication(UserAuthentication userAuthentication, string password)
        {
            var salt = PasswordHash.ScryptGenerateSalt();
            var bytePassword = _defaultEncoding.GetBytes(password);
            var hash = PasswordHash.ScryptHashBinary(bytePassword, salt);
            userAuthentication.Salt = salt;
            userAuthentication.Hash = hash;
            _userDao.UpdateUserAuthentication(userAuthentication);
        }

        private void CreateUserAuthentication(Models.Login loginModel)
        {
            var salt = PasswordHash.ScryptGenerateSalt();
            var bytePassword = _defaultEncoding.GetBytes(loginModel.Password);
            var hash = PasswordHash.ScryptHashBinary(bytePassword, salt);
            var user = _userDao.GetUserByUsername(loginModel.Username);
            _userDao.CreateUserAuthentication(new UserAuthentication
            {
                UserId = user.Id,
                Salt = salt,
                Hash = hash
            });
        }

        public void Dispose()
        {
            _userDao?.Dispose();
        }
    }
}
