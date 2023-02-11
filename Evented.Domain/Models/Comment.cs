using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Models
{
    public class Comment:IBaseModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Text { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime UpdatedAt { get ; set ; }
        public User User { get; set; }  
        public int EventId { get; set; }    
        public Event Event { get; set; }    
    }
}
