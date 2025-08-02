using Dashboard.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabase()
    .AddApiServices()
    .AddApplicationServices()
    .AddAuthenticationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();