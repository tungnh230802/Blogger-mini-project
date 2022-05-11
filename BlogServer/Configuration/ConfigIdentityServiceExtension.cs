using BlogDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogService.ExtensionMethod
{
    public static class ConfigIdentityServiceExtension
    {
        public static IServiceCollection AddConfigIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<AppUser, IdentityRole<Guid>>()
               .AddEntityFrameworkStores<BlogContext>()
               .AddDefaultTokenProviders();
            //services.AddIdentity<AppUser, IdentityRole<Guid>()
            //         .AddEntityFrameworkStores<BlogContext>()
            //         .AddDefaultUI()
            //         .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            });
            return services;
        }
    }
}