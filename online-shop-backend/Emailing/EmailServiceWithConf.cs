using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace online_shop_backend.Emailing
{
    public static class EmailServiceWithConfiguration
    {
        public static void AddEmailServiceWithConf(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<EmailService>();
            services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        }
    }
}