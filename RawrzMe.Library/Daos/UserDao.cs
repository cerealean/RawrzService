﻿using RawrzMe.Library.Mapper;
using System;
using System.Linq;
using RawrzMe.Library.Exceptions;
using RawrzMe.Library.Models;

namespace RawrzMe.Library.Daos
{
    internal class UserDao : IDisposable
    {
        private readonly RawrzMeEntities _rawrzMeEntities = new RawrzMeEntities();

        internal void ExecuteInTransaction(Action action)
        {
            using (var transaction = _rawrzMeEntities.Database.BeginTransaction())
            {
                try
                {
                    action.Invoke();
                    transaction.Commit();
                }
                catch
                {
                    transaction?.Rollback();
                    throw;
                }
            }
        }

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

        internal void CreateUser(NewUser newUser)
        {
            var newUserEntity = new user
            {
                first_name = newUser.FirstName,
                last_name = newUser.LastName,
                is_active = true,
                username = newUser.Username,
                email_addresses = newUser.EmailAddresses.ToEmailAddressEntities(),
                phone_numbers = newUser.PhoneNumbers.ToPhoneNumberEntities(),
                two_factor_authentication = newUser.TwoFactorAuthentication
            };
            _rawrzMeEntities.users.Add(newUserEntity);
            _rawrzMeEntities.SaveChanges();
        }

        internal void UpdateUser(Models.User user)
        {
            var userEntity = _rawrzMeEntities.users.FirstOrDefault(u => u.id == user.Id);
            if (userEntity == null)
            {
                throw new UserNotFoundException($"User with ID {user.Id} not found");
            }
            userEntity.first_name = user.FirstName;
            userEntity.last_name = user.LastName;
            userEntity.is_active = user.IsActive;
            userEntity.two_factor_authentication = user.TwoFactorAuthentication;
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
