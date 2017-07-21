namespace RawrzMe.Library.Mapper
{
    internal static class User
    {
        internal static Models.User ToUserModel(this user user)
        {
            return new Models.User
            {
                Id = user.id,
                Username = user.username,
                FirstName = user.first_name,
                LastName = user.last_name,
                EmailAddresses = user.email_addresses.ToEmails(),
                PhoneNumbers = user.phone_numbers.ToPhones(),
                TwoFactorAuthentication = user.two_factor_authentication
            };
        }
    }
}
