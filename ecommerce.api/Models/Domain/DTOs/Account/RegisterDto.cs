using System.ComponentModel.DataAnnotations;

namespace ecommerce.api.Models.Domain.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "E-Posta en az 3 en fazla 20 karakter olmalıdır.")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad en az 2 en fazla 50 karakter olmalıdır.")]
        [RegularExpression]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyad en az 2 en fazla 50 karakter olmalıdır.")]
        public string SurName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
