using ecommerce.api.Models.Application.IServices;
using ecommerce.api.Models.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.api.Models.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey symmetricSecurityKey;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
        }
        public Task<string> CreateJWTAsync(UserApp user)
        {
            throw new System.NotImplementedException();
        }
    }
}
