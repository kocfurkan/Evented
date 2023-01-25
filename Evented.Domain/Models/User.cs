using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Models
{
    public class User : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Birth { get; set; }
        public string? Image { get; set; }   
        public List<Event>? UserCreated { get; set; }
        public ICollection<UserEvent> EventsJoined { get; set; }    
        public List<Notification>? Notifications { get; set; }
        public List<Comment>? Comment { get; set; }
        public List<Company>? Companies { get; set; }

        public User()
        {
            EventsJoined = new List<UserEvent>();
        }
    }
}
