

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DbDependency
{
    public static IServiceCollection DbService(this IServiceCollection services ,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt=>opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}