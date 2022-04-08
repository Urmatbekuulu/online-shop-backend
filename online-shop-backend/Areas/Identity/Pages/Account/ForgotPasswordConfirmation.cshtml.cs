using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using online_shop_backend.Data;

namespace online_shop_backend.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty(SupportsGet = true)]
        

        public bool DisplayResetLink { get; set; } = true;
        public string ResetLink { get; set; }

        public ForgotPasswordConfirmation(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnGet(string email)
        {
            if (DisplayResetLink && email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler: null,
                        values: new {area = "Identity", code},
                        protocol: Request.Scheme);
                    ResetLink = callbackUrl;
                }
            }
           
          
        }
    }
}
