using api.utility;
using ecommerce.api.Models.Application.IServices;
using ecommerce.api.Models.Application.Services;
using ecommerce.api.Models.Domain.Entities.Users;
using ecommerce.api.Models.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

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
            //.AddSignInManager<SignInManager<UserApp>>() 
            .AddEntityFrameworkStores<EcommerceDbContext>();

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cookie =>
            {
                cookie.Cookie.Name = SD.IdentityAppCookie;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                   //ValidIssuer = builder.Configuration["JWT:Issuer"],
                   ValidateIssuer = false,
                   //ValidAudience = builder.Configuration["JWT:Audience"],
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
                };

                jwt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        //context.Response.Cookies.Append(SD.IdentityAppCookie, context.Request.Cookies[SD.IdentityAppCookie] ?? string.Empty);
                        context.Token = context.Request.Cookies[SD.IdentityAppCookie];
                        return Task.CompletedTask;
                    }
                };
            });
            builder.Services.AddAuthorization();
            builder.Services.AddTransient(typeof(ITokenService), typeof(TokenService));
            return builder;
        }
    }
}
