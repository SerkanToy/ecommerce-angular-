using System.ComponentModel.DataAnnotations;

namespace ecommerce.api.Models.Domain.DTOs.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Boş Bırakmayın.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Bırakmayın.")]
        public string Password { get; set; }
    }
}
