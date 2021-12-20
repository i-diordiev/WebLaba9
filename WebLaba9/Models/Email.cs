using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLaba9.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        
        public string SenderId { get; set; }
        
        public string SenderEmail { get; set; }
        
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        
        public string RecipientId { get; set; }
        
        public string RecipientEmail { get; set; }
        
        [ForeignKey("RecipientId")]
        public User Recipient { get; set; }
        
        public string Title { get; set; }
        
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}