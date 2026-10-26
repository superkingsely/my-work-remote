using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly AppDbContext context;

    public MemberController(AppDbContext context)
    {
        this.context = context;
    }
    [HttpGet("all-members")]
    public async Task<IActionResult> GetAllMembers()
    {
        var members=await context.UserChurches.Select(m => new
        {
            userid=m.UserId,
            username=$"{m.User.LastName} {m.User.FirstName}",
            churchid=m.ChurchId,
            church=m.Church.Name
        }).ToListAsync();
        var res=new
        {
            data=members
        };
        return Ok(res);
    }
}