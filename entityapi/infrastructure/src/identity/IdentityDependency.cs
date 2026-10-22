

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class IdentityDependency
{
    public static IServiceCollection IdentityService(this IServiceCollection services)
    {
        services.AddIdentityCore<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
                
        return services;
    }
}