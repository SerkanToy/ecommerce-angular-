using ecommerce.api.Models.Domain.Entities.Users;
using System.Threading.Tasks;

namespace ecommerce.api.Models.Application.IServices
{
    public interface ITokenService
    {
        Task<string> CreateJWTAsync(UserApp user);
        /*QrCodeDto GenerateQrCode(string email);
        bool ValidateCode(string secretKey, string code);
        string CreateMfaToken(string userName);
        string GetUserNameFromMfaToken(string mfaToken);*/
    }
}
