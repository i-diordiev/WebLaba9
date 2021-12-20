using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebLaba9.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}