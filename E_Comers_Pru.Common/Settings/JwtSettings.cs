using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.Settings
{
    public class JwtSettings
    {
        public bool UseIssuer { get; set; }
        public string? Issuer { get; set; }
        public bool UseAudience { get; set; }
        public string? Audience { get; set; }
        public bool UseKey { get; set; }
        public string? SecretKey { get; set; }
        public bool UseLifeTime { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public bool? RequireExpirationTime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public bool SaveToken { get; set; }
        public double? Minutes { get; set; }
        public bool? UsePolicy { get; set; }
    }
}
