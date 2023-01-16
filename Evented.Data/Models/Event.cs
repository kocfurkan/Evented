using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Data.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public User CreatorUser { get; set; }
        public List<User> JoinedUsers { get; set; }
    }
}
