using System.ComponentModel.DataAnnotations;

namespace MiracSEBTask.Dtos
{
    public record UpdateCustomerDto
    {
        [Required]
        public string SocialSecurityNumber { get; init; }
        public string? EmailAddress { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
