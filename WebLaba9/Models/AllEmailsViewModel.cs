using System.Collections.Generic;

namespace WebLaba9.Models
{
    public class AllEmailsViewModel
    {
        public IEnumerable<Email> EmailsReceived { get; set; }
        
        public IEnumerable<Email> EmailsSent { get; set; }

        public AllEmailsViewModel()
        {
            EmailsReceived = new List<Email>();
            EmailsSent = new List<Email>();
        }
    }
}