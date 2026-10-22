

public class BaseAudit
{
    public Guid Id{get;set;}
    // Audit tracking properties
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }="system";

    public DateTime? LastModifiedAtUtc { get; set; }
    public string? LastModifiedBy { get; set; }

    // Soft delete properties (Highly recommended for database integrity)
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAtUtc { get; set; }
    public string? DeletedBy { get; set; }="system";
}