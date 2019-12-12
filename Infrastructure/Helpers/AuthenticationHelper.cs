using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AeldreplejeCore.Core.Entity;
using Microsoft.IdentityModel.Tokens;

namespace AeldreplejeInfrastructure.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private byte[] secretBytes;

        public AuthenticationHelper(Byte[] secret)
        {
            secretBytes = secret;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name)
            };

            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(secretBytes),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                    null, // audience - not needed (ValidateAudience = false)
                    claims.ToArray(),
                    DateTime.Now, // notBefore
                    DateTime.Now.AddMinutes(60))); // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}