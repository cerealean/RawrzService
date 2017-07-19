namespace RawrzMe.Library.Models
{
    internal class UserAuthentication
    {
        internal int Id { get; set; }
        internal byte[] Hash { get; set; }
        internal byte[] Salt { get; set; }
        internal int UserId { get; set; }
    }
}
