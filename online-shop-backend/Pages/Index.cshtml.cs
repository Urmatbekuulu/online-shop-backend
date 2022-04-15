using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using online_shop_backend.Data;

namespace online_shop_backend.Pages
{
   
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IndexModel(ILogger<IndexModel> logger,SignInManager<ApplicationUser> signinManager)
        {
            _logger = logger;
            _signInManager = signinManager;
        }

        public IActionResult OnGet()
        {
           if(_signInManager.IsSignedIn(User)) return RedirectToPage("Index",new {area = "Admin"});
           return RedirectToPage("Account/Login", new {area = "Identity"});
        }
       
    }
}
