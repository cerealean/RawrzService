using System.Collections.Generic;
using System.Linq;

namespace RawrzMe.Library.Mapper
{
    internal static class Email
    {
        internal static Models.Email[] ToEmails(this IEnumerable<email_addresses> emailAddresses)
        {
            return emailAddresses.Select(ToEmail).ToArray();
        }

        internal static email_addresses[] ToEmailAddressEntities(this IEnumerable<Models.Email> emails)
        {
            return emails.Select(ToEmailAddressEntity).ToArray();
        }

        private static Models.Email ToEmail(this email_addresses emailAddress)
        {
            return new Models.Email
            {
                Id = emailAddress.id,
                EmailAddress = emailAddress.email_address,
                IsPrimary = emailAddress.is_primary,
                IsVerified = emailAddress.is_verified
            };
        }

        private static email_addresses ToEmailAddressEntity(this Models.Email email)
        {
            return new email_addresses
            {
                id = email.Id,
                email_address = email.EmailAddress,
                is_primary = email.IsPrimary,
                is_verified = email.IsVerified
            };
        }
    }
}
