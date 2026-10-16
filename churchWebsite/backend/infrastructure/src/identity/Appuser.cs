

using domain.src.church;
using Microsoft.AspNetCore.Identity;

public class Appuser: IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    // public List<UserMembership>? MemberOfWichChurchAndBranch{get;set;}
     public ICollection<UserMembership> MemberOfWichChurchAndBranch
        { get; set; } = new List<UserMembership>();
    
    public bool LegalMemberOfTheChurch {get;set;}=false;
}
