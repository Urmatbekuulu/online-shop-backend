
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using online_shop_backend.Data;

namespace online_shop_backend.ServicesConfiguration
{
    public static class ServicesConfiguration
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });
        }
        
    }
    
}