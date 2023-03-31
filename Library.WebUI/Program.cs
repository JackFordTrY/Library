using Library.Application;
using Library.Infrastructure;
using Library.WebUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddPresentation();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
