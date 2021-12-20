using System.ComponentModel.DataAnnotations;

namespace WebLaba9.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}