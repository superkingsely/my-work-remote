
// register users

using domain.src.church;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RegisterUsersController : ControllerBase
{
    private readonly UserManager<Appuser> _userManager;
    private readonly Appdbcontext _context;

    public RegisterUsersController(UserManager<Appuser> userManager, Appdbcontext context)
    {
        _userManager = userManager;
        _context = context;
    }


    [HttpPost("register/users/test-church")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterUserDto registerUserDto)
    {
        // 1. Check whether the user already exists.
        var existingUser = await _userManager.FindByEmailAsync(
            registerUserDto.Email);

        if (existingUser is not null)
        {
            return Conflict(new
            {
                Message = "A user with this email already exists."
            });
        }

        // 2. Parse the test church ID into a Guid.
        if (!Guid.TryParse(
            "dc93834e-2f25-4eab-856f-c552e6c0c1c8",
            out var testChurchId))
        {
            return BadRequest(new
            {
                Message = "The test church ID is invalid."
            });
        }

        // 3. Find the church.
        var church = await _context.Churches.FindAsync(testChurchId);

        if (church is null)
        {
            return NotFound(new
            {
                Message = "Test church not found."
            });
        }

        // 4. Create the user.
        var user = new Appuser
        {
            UserName = registerUserDto.Email,
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName
        };

        var result = await _userManager.CreateAsync(
            user,
            registerUserDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new
            {
                Message = "User registration failed.",
                Errors = result.Errors.Select(e => e.Description)
            });
        }

        // 5. Create a membership linked to the saved user.
        var membership = new UserMembership
        {
            UserId = user.Id,
            ChurchId = church.Id,
            ChurchName = church.Name
        };

        try
        {
            _context.UserMemberships.Add(membership);

            await _context.SaveChangesAsync();
        }
        catch
        {
            // Compensate if membership creation fails.
            await _userManager.DeleteAsync(user);

            throw;
        }

        // 6. Return success.
        return Ok(new
        {
            Message = "User registered successfully.",
            UserId = user.Id,
            Email = user.Email,
            ChurchId = church.Id,
            ChurchName = church.Name
        });
    }




    [HttpPost("register/users/my-church")]
    public async Task<IActionResult> RegisterMyChurch([FromBody] RegisterUserDto registerUserDto)
    {

        var user = new Appuser
        {
            UserName = registerUserDto.Email,
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName

        };

        var result = await _userManager.CreateAsync(user, registerUserDto.Password);

        if (result.Succeeded)
        {
            return Ok(new { Message = "User registered successfully." });
        }

        return BadRequest(result.Errors);
    }


    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserDto registerUserDto)
    {
        var user = new Appuser
        {
            UserName = registerUserDto.Email,
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName
        };

        var result = await _userManager.CreateAsync(user, registerUserDto.Password);

        if (result.Succeeded)
        {
            // Assign the "Admin" role to the user
            await _userManager.AddToRoleAsync(user, "Admin");
            return Ok(new { Message = "Admin user registered successfully." });
        }

        return BadRequest(result.Errors);
    }
}