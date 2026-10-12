

// loginusers

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
[ApiController]
public class LoginUserController : ControllerBase
{
    private readonly UserManager<Appuser> _userManager;
    private readonly SignInManager<Appuser> _signInManager;

    public LoginUserController(UserManager<Appuser> userManager, SignInManager<Appuser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid email or password.");
        }

        // You can generate a JWT token here and return it to the client
        // For simplicity, we'll just return a success message
        return Ok("Login successful!");
    }
}