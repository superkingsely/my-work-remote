



namespace domain.src.church;

public class UserMembership : BaseAudit
{
    // Identity user ID; Identity uses string IDs by default.
    public string UserId { get; set; } = string.Empty;

    // Church relationship.
    public Guid ChurchId { get; set; }

    public Church Church { get; set; } = null!;

    public string? ChurchName { get; set; }
}
// public class UserMembership:BaseAudit
// {
//     public string? ChurchId{get;set;}
//     public string? ChurchName{get;set;}
//     public string? ChurchBranchId{get;set;}
//     public string? ChurchBranchName{get;set;}
// }