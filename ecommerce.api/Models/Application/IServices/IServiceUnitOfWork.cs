namespace ecommerce.api.Models.Application.IServices
{
    public interface IServiceUnitOfWork
    {
        IEmailService EmailService { get; }
        ITokenService TokenService { get; }
    }
}
