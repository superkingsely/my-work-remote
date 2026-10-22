

using Scalar.AspNetCore;

public static class AppUi{
    public static WebApplicationBuilder AppUiServices(this WebApplicationBuilder builder)
    {   
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        return builder;
    }
    public static WebApplication UseUiServices(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json","cj api");
            // options.RoutePrefix="swagger";
        });
        app.MapControllers();
        return app;
    }
}