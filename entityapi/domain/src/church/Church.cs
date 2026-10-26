

public class Church:BaseAudit
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    // Relationships (Examples)
    public string? PastorName { get; set; }
    
    // Tracks if this specific local branch is active
    public bool IsActive { get; set; } = true;

    // public ICollection<UserChurch>
}