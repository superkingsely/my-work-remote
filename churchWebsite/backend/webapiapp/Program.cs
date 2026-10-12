


var builder = WebApplication.CreateBuilder(args);

builder.Addappservices();

var app = builder.AddDependencyappui().Build();

app.UseAppservices();

app.Run();