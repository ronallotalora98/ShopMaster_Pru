using E_Comers_Pru.Common.Settings;
using E_Comers_Pru.Services;
using E_Comers_Pru.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
// ConfigureJWTAuthentication(builder.Services, builder.Configuration);
builder.Services.AddServiceInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true)
    {
        Console.WriteLine("Usuario autenticado:");
        foreach (var claim in context.User.Claims)
        {
            Console.WriteLine($"Tipo: {claim.Type}, Valor: {claim.Value}");
        }
    }
    else
    {
        Console.WriteLine("Usuario no autenticado.");
    }
    await next();
});
app.MapControllers();

app.Run();
