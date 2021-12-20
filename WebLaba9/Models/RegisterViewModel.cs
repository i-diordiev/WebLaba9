using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebLaba9.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "MinimumPasswordLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ("PasswordNotEqual"))]
        public string ConfirmPassword { get; set; }
    }
}