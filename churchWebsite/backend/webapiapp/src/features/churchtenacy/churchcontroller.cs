

using domain.src.church;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ChurchController : ControllerBase
{
    private readonly Appdbcontext dbContext;

    public ChurchController(Appdbcontext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet("getchurches")]
    public async Task<IActionResult> GetChurches()
    {
        var churches = await dbContext.Churches.ToListAsync();
        return Ok(churches);
    }
    [HttpPost("createchurch")]
    public async Task<IActionResult> CreateChurch(ChurchCmd church)
    {
        var newChurch = new Church
        {
            Name = church.Name,
            Address = church.Address,
            City = church.City,
            State = church.State,
            ZipCode = church.ZipCode,
            PhoneNumber = church.PhoneNumber,
            Email = church.Email
        };
        dbContext.Churches.Add(newChurch);
        await dbContext.SaveChangesAsync();
        return Ok(newChurch);
    }
  
}