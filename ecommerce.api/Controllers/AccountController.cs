using ecommerce.api.Models.Domain.DTOs.Account;
using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiCoreController
    {      

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login(RegisterDto registerDto)
        {
            var user = await userManager.Users.Where(u => u.UserName == registerDto.Email).FirstOrDefaultAsync();
            IdentityResult result = await userManager.CreateAsync(new UserApp
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                SurName = registerDto.SurName,
                UserName = registerDto.Email,
            });

            if (result.Succeeded)
            {
                return Ok("Register successful");
            }
            return BadRequest("Register failed");
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if(await CheckEmailExistsAsync(registerDto.Email))
            {
                return BadRequest("Email adresi kayıtlı.");
            }

            if (await CheckEmailExistsAsync(registerDto.Email))
            {
                return BadRequest("Username kayıtlı.");
            }

            IdentityResult result = await userManager.CreateAsync(new UserApp
                    {
                        Email = registerDto.Email,
                        Name = registerDto.Name,
                        SurName = registerDto.SurName,
                        UserName = registerDto.Email,
                    });

            if (result.Succeeded)
            {
                return Ok("Register successful");
            }
            return BadRequest("Register failed");
        }
    }
}
