namespace MiracSEBTask.Models
{
    public record Customer
    {
        public int Id { get; init; }
        public string SocialSecurityNumber { get; init; }

        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

    }
}
