

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
public async Task<IActionResult> CreateUser(
    [FromBody] RegisterReq user,
    [FromQuery] string churchId)
{
    // 1. Validate the church ID
    if (!Guid.TryParse(churchId, out var parsedChurchId))
    {
        return BadRequest(new
        {
            message = "A valid church ID is required."
        });
    }

    // 2. Check whether the church exists
    var churchExists = await context.Churches
        .AnyAsync(c => c.Id == parsedChurchId);

    if (!churchExists)
    {
        return NotFound(new
        {
            message = "Church not found."
        });
    }

    // 3. Check whether this user already has an account
    var existUser = await userManager.FindByEmailAsync(user.Email);

    User targetUser;

    if (existUser is not null)
    {
        // 4. The user exists. Check membership in THIS church.
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

        // Verify ownership of the existing account.
        if (!await userManager.CheckPasswordAsync(existUser, user.Password))
        {
            return Unauthorized(new
            {
                message = "Invalid credentials."
            });
        }

        // Existing account, new church membership.
        targetUser = existUser;

        var membership = new UserChurch
        {
            UserId = targetUser.Id,
            ChurchId = parsedChurchId
        };

        context.UserChurches.Add(membership);
        await context.SaveChangesAsync();
    }
    else
    {
        // 5. No account exists: create a new user.
        await using var transaction =
            await context.Database.BeginTransactionAsync();

        targetUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.Email
        };

        var result = await userManager.CreateAsync(
            targetUser,
            user.Password
        );

        if (!result.Succeeded)
        {
            await transaction.RollbackAsync();

            return BadRequest(new
            {
                message = "User registration failed.",
                errors = result.Errors.Select(e => e.Description)
            });
        }

        // Create the user's first church membership.
        var membership = new UserChurch
        {
            UserId = targetUser.Id,
            ChurchId = parsedChurchId
        };

        context.UserChurches.Add(membership);

        await context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    // 6. Retrieve all churches belonging to this user.
    var churches = await context.UserChurches
        .Where(uc => uc.UserId == targetUser.Id)
        .Include(uc => uc.Church)
        .Select(uc => new
        {
            uc.ChurchId,
            ChurchName = uc.Church.Name
        })
        .ToListAsync();

    // 7. Return the user and all their church memberships.
    return Ok(new
    {
        message = "User and church membership processed successfully.",
        registereduser = new
        {
            targetUser.Id,
            targetUser.FirstName,
            targetUser.LastName,
            targetUser.Email
        },
        userchurches = churches
    });
}


}