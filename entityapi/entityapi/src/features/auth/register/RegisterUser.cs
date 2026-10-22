

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly UserManager<User> userManager;

    public RegisterController(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    [HttpPost("user")]
    public async Task<IActionResult> createUser([FromBody] RegisterReq user)
    {
        var existUser=await userManager.FindByEmailAsync(user.Email);
        if(existUser is not null)
        {
            return BadRequest(new {Message="user already exist pls"});
        }

        var newUser= new User
        {
            FirstName=user.FirstName,
            LastName=user.LastName,
            Email=user.Email,
            UserName=user.Email
            
        };
        var result=await userManager.CreateAsync(newUser,user.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new
            {
                message="user not registered meet cj for debug",
                error=errors
            });
            // the below worked!! i.e the string type
            // return BadRequest("user not registered meet cj for debug");
        }
        var res = new
        {
            registereduser=newUser,
            message="registration successful bro"
        };
        return Ok(res);
    }
}