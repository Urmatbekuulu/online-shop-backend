
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace online_shop_backend
{
    public interface IJwtFactory
    {
        Task<(string token, DateTime expiration)> CreateTokenAsync(string userId, string email,
            IEnumerable<Claim> additionalClaims = default);
    }
}