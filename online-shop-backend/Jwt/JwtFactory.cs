using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using online_shop_backend.Data;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace online_shop_backend
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtConfiguration _jwtOptions;
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtFactory(IOptions<JwtConfiguration> jwtOptions, UserManager<ApplicationUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<(string token, DateTime expiration)> CreateTokenAsync(string userId, string email,
            IEnumerable<Claim> additionalClaims = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId),
                new(JwtRegisteredClaimNames.Email, email),
                new(JwtRegisteredClaimNames.Jti, _jwtOptions.JtiGenerator()),
                new(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(_jwtOptions.IssuedAt).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };
            claims.AddRange(additionalClaims ?? Array.Empty<Claim>());
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            var expires = _jwtOptions.Expiration;

            var jwt = new JwtSecurityToken(issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: expires,
                signingCredentials: _jwtOptions.SigningCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return (tokenHandler.WriteToken(jwt), expires);
        }

      

        private static string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}