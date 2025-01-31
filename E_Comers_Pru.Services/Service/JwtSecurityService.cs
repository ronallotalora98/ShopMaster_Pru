using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Settings;
using E_Comers_Pru.Services.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class JwtSecurityService: IJwtSecurityService
    {
        private readonly JwtSettings JwtSettings;

        public JwtSecurityService(IOptions<JwtSettings> jwtSettings)
        {
            JwtSettings = jwtSettings.Value;
        }

        public string GenerateTokenJwt(UserDto dto)
        {
            try
            {
                string? issuer = JwtSettings?.Issuer;
                string? audience = JwtSettings?.Audience;
                byte[] key = Encoding.ASCII.GetBytes(JwtSettings?.SecretKey ?? string.Empty);
                double? expireTime = JwtSettings?.Minutes;

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Sid, dto.Id.ToString() ?? string.Empty));
                claims.Add(new Claim(ClaimTypes.Name, dto.Name ?? string.Empty));
                claims.Add(new Claim(ClaimTypes.Email, dto.Email ?? string.Empty));

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims.ToArray()),
                    Issuer = issuer,
                    Audience = audience,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(expireTime ?? 0),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                });

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public int? ValidateCurrentToken(string token)
        {
            try
            {
                var issuers = JwtSettings.Issuer?.Split(",");
                var audience = JwtSettings.Audience?.Split(",");
                var key = Encoding.UTF8.GetBytes(JwtSettings.SecretKey ?? string.Empty);

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = JwtSettings?.UseIssuer ?? false,
                    ValidateAudience = JwtSettings?.UseAudience ?? false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = JwtSettings?.ValidateIssuerSigningKey ?? false,
                    ValidIssuers = issuers,
                    ValidAudiences = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                }, out SecurityToken validatedToken);

                string? claimSid = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;

                return Convert.ToInt32(claimSid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
