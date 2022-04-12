using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Api.Endpoints.Authorize;

namespace online_shop_backend.Api.Endpoints.Register
{
    public record Result(string message)
    {
        public static Result From(string message) => new(message);
        public static BadRequestObjectResult BadRequest(string message) => new(From(message));
        public static OkObjectResult Ok(string message) => new(From(message));
    }
}