namespace RawrzMe.Library.Mapper
{
    internal static class UserAuthentication
    {
        internal static Models.UserAuthentication ToUserAuthentication(this user_authentication userAuthentication)
        {
            return new Models.UserAuthentication
            {
                Id = userAuthentication.id,
                UserId = userAuthentication.user_id,
                Hash = userAuthentication.hash,
                Salt = userAuthentication.salt
            };
        }
    }
}
