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
        public ApiCoreController(UserManager<UserApp> userManager = null)
        {
            this.userManager = userManager;
        }


        protected async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await userManager.Users.AnyAsync(u => u.Email == email);
        }


        protected async Task<bool> CheckNameExistsAsync(string username)
        {
            return await userManager.Users.AnyAsync(u => u.UserName == username);
        }
    }
}
