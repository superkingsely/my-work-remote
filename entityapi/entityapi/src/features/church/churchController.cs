

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class ChurchController : ControllerBase
{
    private readonly AppDbContext context;

    public ChurchController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpPost("create-church")]
    public async Task<IActionResult> CreateChurch([FromBody] ChurchReq church)
    {
        var newchurch= new Church
        {
            Name=church.Name,
            Address=church.Address
        };
        var result=await context.Churches.AddAsync(newchurch);
        await context.SaveChangesAsync();
        var res= new
        {
            message="church created successfully",
            createdchurch=church
        };
        return Ok(res);
    }
    
    [HttpGet("get-all-churches")]
    public async Task<IActionResult> GetChurches()
    {
        
        var churches=await context.Churches.Select(c =>new
        {
            Id=c.Id,
            name=c.Name,
            address=c.Address,
            createdby=c.CreatedBy,
            // memebers=c.
        }).ToListAsync();

        var res= new
        {   
            message="all churches retrived successfully",
            count=churches.Count,
            allchurches=churches
        };
        return Ok(res);
    }
    
    
    [HttpDelete("delete-church")]
    public async Task<IActionResult> DeleteChurch([FromQuery] string id)
    {
        var isexist= await context.Churches.FindAsync(id);
        if(isexist is null)
        {
            return BadRequest($"church {id} does not exist");
        }
       
        var result= context.Churches.Remove(isexist);
        
        await context.SaveChangesAsync();
        var res= new
        {
            message="church deleted successfully",
            delchurch=isexist
        };
        return Ok(res);
    }

}