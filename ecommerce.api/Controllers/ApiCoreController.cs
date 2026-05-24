using api.utility;
using ecommerce.api.Models.Application.IServices;
using ecommerce.api.Models.Domain.DTOs.UserDto;
using ecommerce.api.Models.Domain.Entities.Users;
using ecommerce.api.Models.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCoreController : ControllerBase
    {
        private EcommerceDbContext _context;
        private UserManager<UserApp> _userManager;
        private SignInManager<UserApp> _signInManager;
        private ITokenService _tokenService;
        private IConfiguration _config;
        private HttpContext _httpContext;

        protected EcommerceDbContext Context => _context ??= HttpContext.RequestServices.GetService<EcommerceDbContext>();
        protected UserManager<UserApp> userManager => _userManager ?? HttpContext.RequestServices.GetService(typeof(UserManager<UserApp>)) as UserManager<UserApp>;
        protected SignInManager<UserApp> signInManager => _signInManager ?? HttpContext.RequestServices.GetService(typeof(SignInManager<UserApp>)) as SignInManager<UserApp>;
        protected ITokenService tokenService => _tokenService ?? HttpContext.RequestServices.GetService(typeof(ITokenService)) as ITokenService;
        protected IConfiguration configuration => _config ?? HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
        protected HttpContext httpContext => _httpContext ??= HttpContext;



        /*public ApiCoreController(UserManager<UserApp> userManager = null, 
                        SignInManager<UserApp> signInManager = null, 
                        ITokenService tokenService = null,
                        IConfiguration configuration = null)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }*/


        protected async Task<bool> CheckEmailExistsAsync(string email)
        {
            bool emailExists = await userManager.Users.AnyAsync(u => u.Email == email);
            return emailExists;
        }


        protected async Task<bool> CheckNameExistsAsync(string username)
        {
            return await userManager.Users.AnyAsync(u => u.UserName == username);
        }

        protected async Task<bool> SendConfirmEmailAsync()
        {
            return true;
        }

        protected async Task<string> UserPasswordValidationAsync(UserApp user, string password, bool lockoutOnFailure)
        {
            if(user.LockoutEnd != null && user.LockoutEnd > DateTimeOffset.UtcNow)
            {
                RemoveJwtCookie();
                return SD.AccountLockedMessage(user.LockoutEnd.Value.DateTime);
            }

            var isCurrentPasswordValid  = await userManager.CheckPasswordAsync(user, password);
            if(!isCurrentPasswordValid)
            {
                await userManager.AccessFailedAsync(user);
                if(user.LockoutEnd != null && user.LockoutEnd > DateTimeOffset.UtcNow)
                {
                    RemoveJwtCookie();
                    return SD.AccountLockedMessage(user.LockoutEnd.Value.DateTime);
                }
                int remaining = SD.MaxFailedAccessAttempts - user.AccessFailedCount;
                return $"Invalid password. {remaining} attempts remaining before account lockout.";
            }
            user.LockoutEnd = null;
            await userManager.ResetAccessFailedCountAsync(user);
            await Context.SaveChangesAsync();
            return null;
        }

        protected async Task<UserAppDto> CreateAppUserDtoAsync(UserApp user) 
        {
            RemoveJwtCookie();
            string jwt = await tokenService.CreateJWTAsync(user);
            SetJWTCookie(jwt);
            var result = await userManager.SetAuthenticationTokenAsync(user, SD.IdentityAppTokenProvider, SD.IdentityAppTokenName, jwt);
            
            return new UserAppDto
            {
                Name = $"{user.Name} {user.SurName}",
                JWT = jwt
            }; 
        }

        private void SetJWTCookie(string jwt)
        {
            var cookieOptions = new CookieOptions
            {                
                //Domain = "https://localhost:7285",
                IsEssential = true,
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(int.Parse(configuration["Jwt:ExpiresInDays"]))
            };
            httpContext.Response.Cookies.Append(SD.IdentityAppCookie, jwt, cookieOptions);
            //Response.Cookies.Append(SD.IdentityAppCookie, jwt, cookieOptions);
        }

        protected void RemoveJwtCookie()
        {
            httpContext.Response.Cookies.Delete(SD.IdentityAppCookie);
        }
    }
}
