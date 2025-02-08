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
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey ?? throw new InvalidOperationException("SecretKey is missing"));

            services.AddAuthentication(confic =>
            {
                confic.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                confic.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
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
            services.AddAuthorization();
           
        }
    }
}
