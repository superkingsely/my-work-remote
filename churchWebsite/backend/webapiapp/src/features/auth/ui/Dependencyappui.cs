

using Scalar.AspNetCore;

public static class Dependencyappui
{
    public static WebApplicationBuilder AddDependencyappui(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        return builder;
    }
    
    public static WebApplication UseDependencyappui(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "CJ API V1");
            // options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });
        app.MapControllers();
        return app;
    }
}