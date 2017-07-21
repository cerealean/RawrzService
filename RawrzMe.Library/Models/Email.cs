namespace RawrzMe.Library.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPrimary { get; set; }
    }
}
