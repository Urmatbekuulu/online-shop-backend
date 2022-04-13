using System;

namespace online_shop_backend.Api.Endpoints.Authorize
{
    public class Response
    {
        public class Result
        {
            public string Username { get; set; }

            public string UserId { get; set; }
            
            public string JwtToken { get; set; }

            public DateTime JwtExpires { get; set; }

            public string RefreshToken { get; set; }

            public DateTime RefreshExpires { get; set; }
        }
    }
}