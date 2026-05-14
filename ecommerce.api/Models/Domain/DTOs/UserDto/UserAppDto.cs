namespace ecommerce.api.Models.Domain.DTOs.UserDto
{
    public class UserAppDto
    {
        public string Name { get; set; }
        public string JWT { get; set; }
        public string MfaToken { get; set; }
    }
}
