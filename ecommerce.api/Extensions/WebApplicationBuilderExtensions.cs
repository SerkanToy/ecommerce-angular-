using api.utility;
using ecommerce.api.Models.Domain.Entities.Users;
using ecommerce.api.Models.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace ecommerce.api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApplicationServer(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EcommerceDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            return builder;
        }

        public static WebApplicationBuilder AddAuthenticationService(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentityCore<UserApp>(opt =>
            {
                opt.Password.RequiredLength = SD.RequiredPasswordLength;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.SignIn.RequireConfirmedAccount = true;
                opt.Lockout.AllowedForNewUsers = false;
                opt.Lockout.MaxFailedAccessAttempts = SD.MaxFailedAccessAttempts;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(SD.DefaultLockoutTimeSpanInDays);
            })
            .AddRoles<RoleApp>()
            .AddEntityFrameworkStores<EcommerceDbContext>()
            .AddDefaultTokenProviders();
            return builder;
        }
    }
}
