

// createcors

public static class CorsExtensions
{
    public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        return builder;
    }   
   
    public static WebApplication UseCorsPolicy(this WebApplication app)
    {
        app.UseCors("AllowAll");
        return app;
    }
}