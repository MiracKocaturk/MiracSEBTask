namespace MiracSEBTask.Dtos
{
    public record RetrieveCustomerDto
    {
        public Guid Id { get; init; }
        public string SocialSecurityNumber { get; init; }

        public string? EmailAddress { get; init; }

        public string? PhoneNumber { get; init; }

    }
}
