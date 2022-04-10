
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.EnableAnnotations();
                setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                });

                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                };

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    [scheme] = Array.Empty<string>(),
                });

                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Online shop backend API",
                    Version = "v1",
                });
                setup.CustomSchemaIds(x => x.FullName);
                setup.DocInclusionPredicate((_, _) => true);
                
            });
        }


    }
    
}