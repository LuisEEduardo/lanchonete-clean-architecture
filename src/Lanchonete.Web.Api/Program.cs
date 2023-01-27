using Lanchonete.Web.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);

var app = builder.Build();

app.UseApiConfig(app.Environment);

app.MapControllers();

app.Run();
