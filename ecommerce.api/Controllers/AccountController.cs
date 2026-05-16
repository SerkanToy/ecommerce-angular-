using api.utility;
using ecommerce.api.Models.Application.IServices;
using ecommerce.api.Models.Domain.DTOs;
using ecommerce.api.Models.Domain.DTOs.Account;
using ecommerce.api.Models.Domain.DTOs.UserDto;
using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ecommerce.api.Controllers
{
    [Route("account/[action]")]
    [ApiController]
    public class AccountController : ApiCoreController
    {
        //private UserManager<UserApp> userManager;
        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager, ITokenService tokenService) : base(userManager, signInManager, tokenService)
        {
            //this.userManager = userManager;
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await userManager.Users.Where(u => u.Email == loginDto.Email.Trim()).FirstOrDefaultAsync();

            if(user == null)
                user = await userManager.Users.Where(u => u.UserName == loginDto.Email.Trim()).FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized(new ApiResponse(401, message: "Kullanıcı bulunamadı", displayByDefault: true));

            if(!user.IsActive)
                return Unauthorized(new ApiResponse(401, message: SM.T_AccountSuspended, displayByDefault: true));

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded)
            {
                RemoveJwtCookie();
                return Unauthorized(new ApiResponse(401, message: "İşlem Başarısız.", displayByDefault: true));
            }

            return Ok("Register successful");
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
                return BadRequest("Kullanıcı adı kayıtlı.");
            }

            UserApp user = new UserApp
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                SurName = registerDto.SurName,
                UserName = registerDto.Email,
                Salt = CreatePasswordHash(registerDto.Password)
            };

            IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            result = await userManager.AddToRoleAsync(user, SD.UserRole);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok("İşlem Başarılı");
        }

        private void SetJWTCookie(string jwt)
        {

        }

        private string CreatePasswordHash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        
    }
}
