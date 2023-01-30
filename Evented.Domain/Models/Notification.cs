using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Models
{
    public class Notification : IBaseModel
    {
        public int Id { get ; set ; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(250)]
        public string Description { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime UpdatedAt { get ; set ; }
        public bool IsValid { get ; set ; } = true;
        public bool IsAccepted { get ; set ; } = false;
        public string UserId { get ; set ; }    
        public User User { get ; set ; }
        public int CompanyId { get ; set ; }    
        public Company Company { get ; set ; }
        public int EventId { get; set; }
        public Event Event { get ; set ; }
    }
}
