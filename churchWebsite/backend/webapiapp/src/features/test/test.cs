
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Test endpoint is working!");
    }
}