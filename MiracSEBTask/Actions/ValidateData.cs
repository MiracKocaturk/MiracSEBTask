using MiracSEBTask.Dtos;

namespace MiracSEBTask.Actions
{
    public class ValidateData
    {
        public static bool ValidateCreateCustomerDto (CreateCustomerDto customerDto)
        {
            if (customerDto is null)
            {
                return false;
            }
            if (customerDto.SocialSecurityNumber is null)
            {
                return false;
            }
            if ((customerDto.SocialSecurityNumber is not null) && !((customerDto.SocialSecurityNumber.Length == 10) || (customerDto.SocialSecurityNumber.Length == 12)))
            {
                return false;
            }
            if (customerDto.EmailAddress is not null && !customerDto.EmailAddress.Contains('@'))
            {
                return false;
            }
            if (customerDto.PhoneNumber is not null && !((customerDto.PhoneNumber.Length == 9) || (customerDto.PhoneNumber.Length == 12)))
            {
                return false;
            }
            if (customerDto.PhoneNumber is not null && (customerDto.PhoneNumber.Length == 12) && !(customerDto.PhoneNumber.StartsWith("+46")))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateUpdateCustomerDto(UpdateCustomerDto customerDto)
        {
            if (customerDto is null)
            {
                return false;
            }
            if (customerDto.SocialSecurityNumber is null)
            {
                return false;
            }
            if ((customerDto.SocialSecurityNumber is not null) && !((customerDto.SocialSecurityNumber.Length == 10) || (customerDto.SocialSecurityNumber.Length == 12)))
            {
                return false;
            }
            if (customerDto.EmailAddress is not null && !customerDto.EmailAddress.Contains('@'))
            {
                return false;
            }
            if (customerDto.PhoneNumber is not null && !((customerDto.PhoneNumber.Length == 9) || (customerDto.PhoneNumber.Length == 12)))
            {
                return false;
            }
            if (customerDto.PhoneNumber is not null && (customerDto.PhoneNumber.Length == 12) && !(customerDto.PhoneNumber.StartsWith("+46")))
            {
                return false;
            }
            return true;
        }
    }
}
