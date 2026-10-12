
// register users

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class RegisterUsersController : ControllerBase
{
    private readonly UserManager<Appuser> _userManager;

    public RegisterUsersController(UserManager<Appuser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register/users")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
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