using System.ComponentModel.DataAnnotations;

namespace MiracSEBTask.Dtos
{
    public record RetrieveCustomerDto
    {
        public Guid Id { get; init; }
        [Required]
        public string SocialSecurityNumber { get; init; }

        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

    }
}
