

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Dependencydatabase
{
    public static WebApplicationBuilder AddDependencydatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<Appdbcontext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        return builder;
    }
   
}