
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Appdbcontext : IdentityDbContext<Appuser>
{
    public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
    {
    }
}