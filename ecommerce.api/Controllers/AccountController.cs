using ecommerce.api.Models.Domain.DTOs.Account;
using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<UserApp> userManager;
        public AccountController(UserManager<UserApp> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = await userManager.Users.Where(u => u.UserName == registerDto.Email).FirstOrDefaultAsync();
            return Ok("Register successful");
        }
    }
}
