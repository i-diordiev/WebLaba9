using System.ComponentModel.DataAnnotations;

namespace WebLaba9.Models
{
    public class SendEmailViewModel
    {
        [Required]
        public string SendTo { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Message { get; set; }
    }
}