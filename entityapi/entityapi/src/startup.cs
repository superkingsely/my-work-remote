

public static class StartUp
{
    public static void RegAppServices(this WebApplicationBuilder builder)
    {
        builder.AppUiServices();
        builder.Services.IdentityService()
                        .DbService(builder.Configuration);
    }
    public static void UseAppServices(this WebApplication app)
    {
        app.UseUiServices();
    }
}