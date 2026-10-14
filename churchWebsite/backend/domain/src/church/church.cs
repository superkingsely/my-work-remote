

 namespace domain.src.church;
public class Church: BaseAudit
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    // public ICollection<ChurchMembership>? Members { get; set; }=new List<ChurchMembership>();
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public bool ItHasBranch {get;set;}=false;
    public ICollection<ChurchBranch>? ChurchBranches { get; set; } = new List<ChurchBranch>();
    // prop list of global usermember
    

}