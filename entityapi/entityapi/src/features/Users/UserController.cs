
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> userManager;

    public UserController(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users=await userManager.Users.ToListAsync();
        var count=users.Count;
        var transUser = users.Select(u => new
        {
            Id=u.Id,
            firstname=u.FirstName,
            lastname=u.LastName,
            email=u.Email,
            userchurches=u.userChurches,
            nosofchurchgoingto=u.userChurches.Count
        });
        var res = new
        {   
            count=count,
            Users=transUser
        };
        return Ok(res);
    }
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUsers([FromQuery] string email)
    {
        var isusers=await userManager.FindByEmailAsync(email);
        if(isusers is null)
        {
            return BadRequest("user cant be found");
        }
        var result=await userManager.DeleteAsync(isusers);
        if (!result.Succeeded)
        {
            var error=result.Errors.Select(e=>e.Description);
            return BadRequest(new
            {
                message="user failed to delete",
                error=error
            });
        }
        var res = new
        {   
            message="delete succefull",
            User=isusers
        };
        return Ok(res);
    }
}