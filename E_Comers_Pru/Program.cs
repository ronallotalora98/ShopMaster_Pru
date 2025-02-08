using E_Comers_Pru.Common.Settings;
using E_Comers_Pru.Services;
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("Authorization"))
    {
        var token = context.Request.Headers["Authorization"].ToString();
        Console.WriteLine($"Token recibido: {token}");
    }
    else
    {
        Console.WriteLine("No se recibió token en el header Authorization.");
    }
    await next();
});

app.MapControllers();

app.Run();
