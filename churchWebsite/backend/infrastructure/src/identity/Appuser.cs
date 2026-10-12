

using Microsoft.AspNetCore.Identity;

public class Appuser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}