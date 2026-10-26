

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
    
    public DbSet<Church> Churches{get;set;}
    public DbSet<UserChurch> UserChurches => Set<UserChurch>();
}