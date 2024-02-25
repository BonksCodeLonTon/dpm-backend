using DPM.Applications.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Services
{
    internal class JwtService : IJwtService
    {
        public class Options
        {
            public static readonly string SectionName = "Jwt";

            [Required]
            public string SecretKey { get; set; } = default!;
        }

        private readonly SymmetricSecurityKey _securityKey;
        public JwtService(IOptionsSnapshot<Options> options)
        {
            var secretKey = Convert.FromBase64String(options.Value.SecretKey);
            _securityKey = new SymmetricSecurityKey(secretKey);
        }

        public string Encode(IEnumerable<Claim> claims, int ttl = 24 * 60)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                EncryptingCredentials = new EncryptingCredentials(
                _securityKey,
                SecurityAlgorithms.Aes256KW,
                SecurityAlgorithms.Aes256CbcHmacSha512),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(ttl),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<Claim> Decode(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var result = tokenHandler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    TokenDecryptionKey = _securityKey,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    SignatureValidator = (string token, TokenValidationParameters parameters) => new JwtSecurityToken(token),
                }, out var _);

            return result.Claims;
        }
    }

}
