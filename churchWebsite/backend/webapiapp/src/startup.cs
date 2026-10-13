

public static class Startup
{
    public static WebApplicationBuilder Addappservices(this WebApplicationBuilder builder)
    {
        builder.AddDependencyappui();
        builder.Services.AddControllers();
        builder.AddDependencyidentity();
        builder.AddDependencydatabase();
        builder.AddValidatejwt(builder.Configuration);
        builder.AddCorsPolicy();

        builder.Services.AddScoped<CreateJwt>();
        return builder;
    }

    public static WebApplication UseAppservices(this WebApplication app)
    {
        app.UseDependencyappui();
        app.UseCorsPolicy();
        app.UseValidatejwt();
        app.MapControllers();
        return app;
    }
}