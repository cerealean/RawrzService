using System.Collections.Generic;
using System.Linq;
using RawrzMe.Library.Enums;

namespace RawrzMe.Library.Mapper
{
    internal static class Phone
    {
        internal static Models.Phone[] ToPhones(this IEnumerable<phone_numbers> phoneNumbers)
        {
            return phoneNumbers.Select(ToPhone).ToArray();
        }

        internal static phone_numbers[] ToPhoneNumberEntities(this IEnumerable<Models.Phone> phones)
        {
            return phones.Select(ToPhoneNumberEntity).ToArray();
        }

        private static Models.Phone ToPhone(this phone_numbers phoneNumber)
        {
            return new Models.Phone
            {
                Id = phoneNumber.id,
                PhoneNumber = phoneNumber.phone_number,
                IsPrimary = phoneNumber.is_primary,
                IsVerified = phoneNumber.is_verified,
                CanText = phoneNumber.can_text,
                PhoneType = (PhoneType) phoneNumber.phone_type_id
            };
        }

        private static phone_numbers ToPhoneNumberEntity(this Models.Phone phone)
        {
            return new phone_numbers
            {
                id = phone.Id,
                phone_number = phone.PhoneNumber,
                is_primary = phone.IsPrimary,
                is_verified = phone.IsVerified,
                can_text = phone.CanText,
                phone_type_id = (int) phone.PhoneType
            };
        }
    }
}
