
using System.Diagnostics;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using online_shop_backend.Api.Endpoints.Authorize;
using online_shop_backend.Data;
using online_shop_backend.Emailing;
using Org.BouncyCastle.Asn1.Ocsp;
using Swashbuckle.AspNetCore.Annotations;

namespace online_shop_backend.Api.Endpoints.Register
{
    public class RegistrationEndpoint:EndpointBaseAsync.WithRequest<Request.Register>.WithActionResult<Result>
    {
        private readonly EmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegistrationEndpoint> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegistrationEndpoint(EmailService emailService, UserManager<ApplicationUser> userManager,
            ILogger<RegistrationEndpoint> logger,RoleManager<IdentityRole> roleManager)
        {
            _emailService = emailService;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
        }

        [HttpPost("api/register")]
        [SwaggerOperation(
            Summary = "Registers a user",
            Description = "Registers a user",
            OperationId = "auth.signUp",
            Tags = new[] {"Auth.SignUp"})]
        public override async Task<ActionResult<Result>> HandleAsync(Request.Register request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            if (await CheckIsUserRegistered(request))
                return BadRequest("hello");
            var user = new ApplicationUser();
            user.Email = request.Email;
            user.UserName = request.Email;

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) return BadRequest("Something was wrong, please try again");

            
            await _userManager.AddToRoleAsync(user, Roles.User);
            var verificationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
           // await _emailService.SendVerificationEmailAsync(user.Email, verificationToken, Request.Host.Value);

            return Ok(Result.From("rigistered sucessfully"));
        }

        private async  Task<bool> CheckIsUserRegistered(Request.Register request)
        {
            if (await _userManager.FindByEmailAsync(request.Email) == null)
                return false;
            //else _emailService.SendAlreadyRegisteredEmailAsync(request.Email, Request.Host.Value);
            return true;

        }
    }
}