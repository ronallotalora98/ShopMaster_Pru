using E_Comers_Pru.Common.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public  class AuthenticationMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly JwtSettings JwtSettings;

        public AuthenticationMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
        {
            Next = next;
            JwtSettings = jwtSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            Endpoint? endpoint = context?.GetEndpoint();
            bool requireAutorization = endpoint?.Metadata?.GetMetadata<AuthorizeAttribute>() != null;

            if (requireAutorization)
            {
                (bool, string?) validateKey = (false, null);
                string? authHeader = context?.Request.Headers["Authorization"] ?? "";

                if (authHeader?.Contains("Bearer") ?? false)
                {
                    char[] bearerWord = { 'B', 'e', 'a', 'r', 'e', 'r' };
                    authHeader = authHeader.TrimStart(bearerWord);
                }

                validateKey = ValidateToken(authHeader, context);

                if (!validateKey.Item1)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Error: Unauthorized. \n" + validateKey.Item2);
                    return;
                }
            }

            await Next(context);
        }

        public (bool, string?) ValidateToken(string? token, HttpContext context)
        {
            if (token == null) return (false, null);
            try
            {
                var issuers = JwtSettings.Issuer?.Split(",");
                var audience = JwtSettings.Audience?.Split(",");
                var key = Encoding.UTF8.GetBytes(JwtSettings.SecretKey ?? string.Empty);

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token.Trim(), new TokenValidationParameters
                {
                    ValidateIssuer =  false,
                    ValidateAudience = false,
                    ValidateLifetime = JwtSettings?.UseLifeTime ?? false,
                    ValidateIssuerSigningKey = JwtSettings?.ValidateIssuerSigningKey ?? false,
                    //ValidIssuers = issuers,
                    // ValidAudiences = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // LifetimeValidator = this.LifetimeValidator
                }, out SecurityToken validatedToken);

                Task.Run(async () => await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true }));

                var jwtToken = (JwtSecurityToken)validatedToken;

                return (true, "OK");
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return (false, error);
            }
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
