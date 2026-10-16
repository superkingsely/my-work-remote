

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
    public UserController(Appdbcontext dbContext, UserManager<Appuser> userManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        // Constructor implementation
    }


    [HttpGet("getusers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userManager.Users
            .Include(u => u.MemberOfWichChurchAndBranch)
            .Select(u => new
            {
                Names = $"{u.FirstName} {u.LastName}",
                Email = u.Email,
                WhichChurch = u.MemberOfWichChurchAndBranch
                    .Select(m => new
                    {
                        m.ChurchId,
                        m.ChurchName
                    })
                    .ToList()
            })
            .ToListAsync();

        return Ok(users);
    }
}
