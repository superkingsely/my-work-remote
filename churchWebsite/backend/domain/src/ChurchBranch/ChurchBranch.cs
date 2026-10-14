


namespace domain.src.church;

public class ChurchBranch : BaseAudit
{
    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    // Foreign key: the church this branch belongs to.
    public Guid ChurchId { get; set; }

    // Navigation property.
    public Church Church { get; set; } = null!;
}
