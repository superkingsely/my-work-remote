using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class Dependencyidentity
{
    
public static WebApplicationBuilder AddDependencyidentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<Appuser, IdentityRole>()
            .AddEntityFrameworkStores<Appdbcontext>()
            .AddDefaultTokenProviders();

        return builder;
    }

    public static WebApplication UseDependencyidentity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

   
}