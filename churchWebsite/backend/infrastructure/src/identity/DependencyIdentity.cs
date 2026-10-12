using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class Dependencyidentity
{
    
public static WebApplicationBuilder AddDependencyidentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<Appuser, IdentityRole>(options =>
        {
            // Password requirements
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                // options.Password.

                // User account settings
                options.User.RequireUniqueEmail = true;

                // Lockout after repeated failed login attempts
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan =
                    TimeSpan.FromMinutes(15);
                options.Lockout.AllowedForNewUsers = true;

                // Account confirmation
                options.SignIn.RequireConfirmedEmail = false;

        })
            .AddEntityFrameworkStores<Appdbcontext>()
            .AddDefaultTokenProviders();

        return builder;
    }

  

   
}