

public static class Startup
{
    public static WebApplicationBuilder Addappservices(this WebApplicationBuilder builder)
    {
        builder.AddDependencyappui();
        builder.AddDependencyidentity();
        builder.AddDependencydatabase();
        return builder;
    }

    public static WebApplication UseAppservices(this WebApplication app)
    {
        app.UseDependencyappui();
        return app;
    }
}