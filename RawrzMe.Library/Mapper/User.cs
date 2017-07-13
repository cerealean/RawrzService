namespace RawrzMe.Library.Mapper
{
    internal static class User
    {
        internal static Models.User ToUserModel(this RawrzMe.Library.User user)
        {
            return new Models.User
            {
                Id = user.id,
                Username = user.username,
                FirstName = user.first_name,
                LastName = user.last_name,
                Email = user.email,
                Phone = user.phone,
                CanEmail = user.can_email,
                CanText = user.can_text,
                TwoFactorAuthentication = user.two_factor_authentication
            };
        }
    }
}
