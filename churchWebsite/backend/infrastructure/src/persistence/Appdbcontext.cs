
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using domain.src.church;
public class Appdbcontext : IdentityDbContext<Appuser>
{
    public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
    {
    }

    public DbSet<Church> Churches{get;set;}
    public DbSet<ChurchBranch> ChurchBranches{get;set;}
    public DbSet<UserMembership> UserMemberships{get;set;}
}