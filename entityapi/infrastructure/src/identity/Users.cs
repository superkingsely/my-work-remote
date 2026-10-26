

using Microsoft.AspNetCore.Identity;

public class User:IdentityUser
{
    public string FirstName { get; set; }="";
    public string LastName { get; set; }="";

    public ICollection<UserChurch> userChurches{get;set;}=new List<UserChurch>();
}