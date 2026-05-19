using api.utility;
using ecommerce.api.Models.Application.IServices;
using ecommerce.api.Models.Application.Services;
using ecommerce.api.Models.Domain.Entities.Users;
using ecommerce.api.Models.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ecommerce.api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static IServiceCollection AddApplicationServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<EcommerceDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("SqlServer")!;
                options.UseSqlServer(connectionString);
            });

            return service;
        }

        public static IServiceCollection AddAuthenticationService(this IServiceCollection service)
        {
            service.AddIdentityCore<UserApp>(opt =>
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
            .AddSignInManager<SignInManager<UserApp>>() 
            .AddEntityFrameworkStores<EcommerceDbContext>();

            service.AddTransient(typeof(ITokenService), typeof(TokenService));
            return service;
        }
    }
}
