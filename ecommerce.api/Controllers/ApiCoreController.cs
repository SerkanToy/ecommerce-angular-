using api.utility;
using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCoreController : ControllerBase
    {
        protected UserManager<UserApp> userManager;
        protected SignInManager<UserApp> signInManager;
        public ApiCoreController(UserManager<UserApp> userManager = null, SignInManager<UserApp> signInManager = null)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


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

        protected async Task<string> UserPasswordValidationAsync(UserApp user, string password)
        {
            return null;
        }

        protected void RemoveJwtCookie()
        {
            Response.Cookies.Delete(SD.IdentityAppCookie);
        }
    }
}
