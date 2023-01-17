using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Data.Models
{
 
    public class Event : IBaseModel
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Topic { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(250)]
        public string Description { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }    
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsValid { get; set; } = true;
        public DateTime BeginsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public string CreatorId { get; set; }
        public User CreatorUser { get; set; }
        public List<User> UserJoined { get; set; }
        public List<Comment> Comments { get; set; }
        public Company? HiredCompany { get; set; }
    }
}
