using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Birth { get; set; }
        public string? Image { get; set; }   
        public List<Event>? UserCreated { get; set; }
        public List<Event>? EventJoined { get; set; }
        public List<Notification>? Notifications { get; set; }
        public List<Comment>? Comment { get; set; }
        public List<Company>? Companies { get; set; }
    }
}
