

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

// [Authorize]
public class UserController : ControllerBase
{
    private readonly Appdbcontext dbContext;
    private readonly UserManager<Appuser> userManager;

    // Controller implementation
    public UserController(Appdbcontext dbContext,UserManager<Appuser> userManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        // Constructor implementation
    }


    [HttpGet("getusers")]
    public async Task<IActionResult> GetUsers()
    {
        // Logic to retrieve users
        var users = await userManager.Users.ToListAsync();
        var res=users.Select(u => new
        {
            Names =$"{u.FirstName} {u.LastName}",
            Email = u.Email,
            WhichChurch = u.MemberOfWichChurchAndBranch
        }).ToList();
        return Ok(res);
    }
}
       