using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace online_shop_backend.Areas.Admin.Pages
{
    [Authorize(Roles = "ADMINSTRATOR")]
    public class IndexModel: PageModel
    {
        public void OnGet()
        {
            
        }
    }
}