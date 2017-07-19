using System;
using System.Text;
using RawrzMe.Library.Daos;
using RawrzMe.Library.Exceptions;
using RawrzMe.Library.Models;
using Sodium;

namespace RawrzMe.Library.Services
{
    public class Authentication : IDisposable
    {
        private readonly UserDao _userDao = new UserDao();
        private readonly Encoding _defaultEncoding = Encoding.UTF8;

        public bool AreUserCredentialsValid(string username, string password)
        {
            var userAuthentication = _userDao.GetUserAuthenticationByUsername(username);
            var bytePassword = _defaultEncoding.GetBytes(password);
            return PasswordHash.ScryptHashStringVerify(userAuthentication.Hash, bytePassword);
        }

        public void CreateNewUser(NewUser newUser)
        {
            _userDao.ExecuteInTransaction(() =>
            {
                _userDao.CreateUser(newUser);
                CreateUserAuthentication(newUser.Username, newUser.Password);
            });
        }

        public void UpdatePassword(PasswordChange passwordChange)
        {
            var userAuthentication = _userDao.GetUserAuthenticationByUsername(passwordChange.Username);

            if (userAuthentication == null)
            {
                throw new UserNotFoundException($"Given user {passwordChange.Username} was not found");
            }

            UpdateUserAuthentication(userAuthentication, passwordChange.NewPassword);
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

        private void CreateUserAuthentication(string username, string password)
        {
            var salt = PasswordHash.ScryptGenerateSalt();
            var bytePassword = _defaultEncoding.GetBytes(password);
            var hash = PasswordHash.ScryptHashBinary(bytePassword, salt);
            var user = _userDao.GetUserByUsername(username);
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
