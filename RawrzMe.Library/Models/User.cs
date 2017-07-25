namespace RawrzMe.Library.Models
{
    public class User
    {
        public int Id;
        public string Username;
        public string FirstName;
        public string LastName;
        public Email[] EmailAddresses = {};
        public Phone[] PhoneNumbers = {};
        public bool TwoFactorAuthentication;
        public Authentication Authentication;
        public bool IsActive;
    }
}