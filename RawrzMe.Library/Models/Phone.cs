using RawrzMe.Library.Enums;

namespace RawrzMe.Library.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
        public bool CanText { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPrimary { get; set; }
    }
}
