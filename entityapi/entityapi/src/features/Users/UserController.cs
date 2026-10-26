
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
        // 1. Retrieve users, their memberships, and their churches
        var users = await userManager.Users
            .Include(u => u.userChurches)
            .ThenInclude(uc => uc.Church)
            .ToListAsync();

        // 2. Format the response
        var transUser = users.Select(u => new
        {
            id = u.Id,
            firstname = u.FirstName,
            lastname = u.LastName,
            email = u.Email,

            userchurches = u.userChurches.Select(uc => new
            {
                churchid = uc.ChurchId,
                churchname = uc.Church.Name
            }).ToList(),

            nosofchurchgoingto = u.userChurches.Count
        }).ToList();

        // 3. Return the result
        return Ok(new
        {
            count = transUser.Count,
            users = transUser
        });
    }

    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUsers([FromQuery] string id)
    {
        var isusers = await userManager.FindByIdAsync(id);

        if (isusers is null)
        {
            return BadRequest("user cant be found");
        }
        var result = await userManager.DeleteAsync(isusers);
        if (!result.Succeeded)
        {
            var error = result.Errors.Select(e => e.Description);
            return BadRequest(new
            {
                message = "user failed to delete",
                error = error
            });
        }
        var res = new
        {
            message = "delete succefull",
            User = isusers
        };
        return Ok(res);
    }
}