using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Api.Endpoints.Register;
using online_shop_backend.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace online_shop_backend.Api.Endpoints.Authorize
{
    public class Login:EndpointBaseAsync.WithRequest<Request.Input>.WithResult<ActionResult<Response.Result>>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Login(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost("api/login")]
        [SwaggerOperation(
            Summary = "Authenticates the user",
            Description = "Authenticates the user",
            OperationId = "auth.authenticate",
            Tags = new[] { "Auth.SignIn" })]
        public override async Task<ActionResult<Response.Result>> HandleAsync(Request.Input request, CancellationToken cancellationToken = new CancellationToken())
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest("empty username");

            ApplicationUser user = new ApplicationUser(){Email = request.Email};
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password,false,false);
            if (!result.Succeeded)
                return BadRequest("Email or password is invalid");

            return new Response.Result("success");
        }
    }
}