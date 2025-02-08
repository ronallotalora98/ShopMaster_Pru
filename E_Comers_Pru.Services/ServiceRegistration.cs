using E_Comers_Pru.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using E_Comers_Pru.Common.Settings;
using E_Comers_Pru.Services.IService;
using E_Comers_Pru.Services.Service;
using E_Comers_Pru.Services.Mapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Comers_Pru.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoryInfrastructure(configuration);
            ConfigureJWToken(services, configuration);
            services.AddAutoMapper(typeof(ConfigurationMapper));

            services.AddScoped<IJwtSecurityService, JwtSecurityService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProducService, ProducService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IUserService, UserService>();



        }

        public static void ConfigureJWToken(IServiceCollection services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey.ToString() ?? throw new InvalidOperationException("SecretKey is missing"));

            services.AddAuthentication(confic =>
            {
                confic.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                confic.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(confic =>
            {
                confic.RequireHttpsMetadata = false;
                confic.SaveToken = true;
                confic.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            // ValidIssuer = jwtSettings.Issuer,
            //            ValidateIssuer = false,
            //            ValidateAudience = false,
            //            // ValidAudience = jwtSettings.Audience,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero // Para evitar discrepancias de tiempo
            //        };
            //    });

            //var jwtSettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();

            //if (jwtSettings?.SecretKey != null)
            //{
            //    // Convertir la clave secreta en un arreglo de bytes
            //    var secretKey = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

            //    services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = "Bearer";
            //        options.DefaultScheme = "Bearer";
            //        options.DefaultChallengeScheme = "Bearer";
            //    })
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = jwtSettings.RequireHttpsMetadata; // Respetar configuración
            //        options.SaveToken = jwtSettings.SaveToken;

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            // Validar clave secreta
            //            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
            //            IssuerSigningKey = new SymmetricSecurityKey(secretKey),

            //            // Validar Emisor (Issuer)
            //            ValidateIssuer = jwtSettings.UseIssuer,
            //            ValidIssuer = jwtSettings.UseIssuer ? jwtSettings.Issuer : null,

            //            // Validar Audiencia (Audience)
            //            ValidateAudience = jwtSettings.UseAudience,
            //            ValidAudience = jwtSettings.UseAudience ? jwtSettings.Audience : null,

            //            // Validar tiempo de vida del token
            //            RequireExpirationTime = jwtSettings.RequireExpirationTime ?? false,
            //            ValidateLifetime = jwtSettings.UseLifeTime,

            //            // Permitir sincronización de reloj (opcional, recomendado)
            //            ClockSkew = TimeSpan.Zero
            //        };

            //        // Eventos para depuración
            //        options.Events = new JwtBearerEvents
            //        {
            //            OnAuthenticationFailed = context =>
            //            {
            //                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
            //                return Task.CompletedTask;
            //            },
            //            OnTokenValidated = context =>
            //            {
            //                Console.WriteLine("Token validated successfully.");
            //                return Task.CompletedTask;
            //            }
            //        };
            //    });

            //    // Registrar JwtSettings como singleton para otras dependencias
            //    services.AddSingleton(jwtSettings);

            //    // Agregar servicios de autorización
            //    services.AddAuthorization();
            //}
            //else
            //{
            //    throw new Exception("La configuración de JwtSettings no está correctamente definida.");

            //}
        }
    }
}
