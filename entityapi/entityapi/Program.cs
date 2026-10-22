var builder=WebApplication.CreateBuilder(args);

builder.RegAppServices();

var app =builder.Build();

app.UseAppServices();

app.Run();