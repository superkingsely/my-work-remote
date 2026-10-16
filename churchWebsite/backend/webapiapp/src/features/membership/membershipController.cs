

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MembershipController : ControllerBase
{
    private readonly Appdbcontext context;

    // Controller implementation
    public MembershipController(Appdbcontext context)
    {
        this.context = context;
        // Constructor implementation
    }

    [HttpGet("debug/memberships")]
    public async Task<IActionResult> GetMemberships()
    {
        var memberships = await context.UserMemberships
            .Select(m => new
            {
                Id = m.Id,
                m.UserId,
                m.ChurchId,
                m.ChurchName
            })
            .ToListAsync();

        return Ok(memberships);
    }
}