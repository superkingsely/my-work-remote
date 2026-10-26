

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly AppDbContext context;

    public RegisterController(UserManager<User> userManager, AppDbContext context)
    {
        this.userManager = userManager;
        this.context = context;
    }

    [HttpPost("user")]
    public async Task<IActionResult> createUser([FromBody] RegisterReq user, [FromQuery] string churchId)
    {
        // convert string to guid
        if (!Guid.TryParse(churchId, out var parsedChurchId))
        {
            return BadRequest(new
            {
                message = "A valid church ID is required."
            });
        }

        var existchurch = await context.Churches.AnyAsync(c => c.Id == parsedChurchId);
        if (!existchurch)
        {
            return NotFound(new
            {
                message = "Church not found."
            });
        }
        var existUser = await userManager.FindByEmailAsync(user.Email);
        if (existUser is not null)
        {
            // check if user exist in the current church reg

            var alreadyMember = await context.UserChurches
          .AnyAsync(uc =>
              uc.UserId == existUser.Id &&
              uc.ChurchId == parsedChurchId);

            if (alreadyMember)
            {
                return Conflict(new
                {
                    message = "This user is already a member of this church."
                });
            }
            // return BadRequest(new { Message = "user already exist pls" });
        }
       
        await using var transaction =
        await context.Database.BeginTransactionAsync();
        var newUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.Email

        };
        var result = await userManager.CreateAsync(newUser, user.Password);
        if (!result.Succeeded)
        {
            await transaction.RollbackAsync();
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new
            {
                message = "user not registered meet cj for debug",
                error = errors
            });
            // the below worked!! i.e the string type
            // return BadRequest("user not registered meet cj for debug");
        }
        var membership = new UserChurch
        {
            UserId = newUser.Id,
            ChurchId = parsedChurchId
        };
        context.UserChurches.Add(membership);

        await context.SaveChangesAsync();
        await transaction.CommitAsync();
        var churches = await context.UserChurches
            .Where(uc => uc.UserId == newUser.Id)
            .Include(uc => uc.Church)
            .Select(uc => new
            {
                uc.ChurchId,
                ChurchName = uc.Church.Name
            })
            .ToListAsync();

        var res = new
        {
            message = "registration successful bro",
            userchurches = churches,
            registereduser = new
            {
                newUser.Id,
                newUser.FirstName,
                newUser.LastName,
                newUser.Email
            },

        };
        return Ok(res);
    }


}