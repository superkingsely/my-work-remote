

public static class StartUp
{
    public static void RegAppServices(this WebApplicationBuilder builder)
    {
        builder.AppUiServices();
    }
    public static void UseAppServices(this WebApplication app)
    {
        app.UseUiServices();
    }
}