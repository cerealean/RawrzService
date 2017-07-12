namespace RawrzService.Models
{
    public class User
    {
        public int Id;
        public string Username;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Phone;
        public bool CanText;
        public bool CanEmail;
        public bool TwoFactorAuthentication;
        public Authentication Authentication;
    }
}