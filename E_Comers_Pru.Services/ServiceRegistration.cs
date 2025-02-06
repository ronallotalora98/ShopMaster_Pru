using E_Comers_Pru.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using E_Comers_Pru.Common.Settings;
using Microsoft.IdentityModel.Tokens;
using E_Comers_Pru.Services.IService;
using E_Comers_Pru.Services.Service;
using E_Comers_Pru.Services.Mapper;

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
            IOptions<JwtSettings> jwtSettings = services.BuildServiceProvider().GetService<IOptions<JwtSettings>>();

            if (jwtSettings?.Value.SecretKey != null)
            {
                byte[] encript = Encoding.ASCII.GetBytes(jwtSettings?.Value?.SecretKey ?? "");
                services.AddAuthentication(delegate (AuthenticationOptions auth)
                {
                    auth.DefaultAuthenticateScheme = "Bearer";
                    auth.DefaultScheme = "Bearer";
                    auth.DefaultChallengeScheme = "Bearer";
                }).AddJwtBearer(delegate (JwtBearerOptions bearer)
                {
                    bearer.RequireHttpsMetadata = jwtSettings?.Value?.RequireHttpsMetadata ?? false;
                    bearer.SaveToken = jwtSettings?.Value?.SaveToken ?? false;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = jwtSettings?.Value?.ValidateIssuerSigningKey ?? false,
                        IssuerSigningKey = new SymmetricSecurityKey(encript),
                        ValidateIssuer = jwtSettings?.Value?.UseIssuer ?? false,
                        ValidIssuer = jwtSettings?.Value.Issuer,
                        ValidAudience = jwtSettings?.Value.Audience,
                        ValidateAudience = jwtSettings?.Value.UseAudience ?? false,
                        RequireExpirationTime = jwtSettings?.Value.RequireExpirationTime ?? false,
                        ValidateLifetime = jwtSettings?.Value.UseLifeTime ?? false
                    };
                });

                services.AddSingleton(jwtSettings?.Value ?? new());
                services.AddAuthorization();
            }
        }
    }
}
