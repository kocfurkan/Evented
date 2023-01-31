using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Models
{
    public class Company : IBaseModel
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Description { get; set; }
        [Required, StringLength(100), DisplayName("Field of Work")]
        public string FieldofWork { get; set; }
        public string OwnedById { get; set; }
        public User OwnedBy { get; set; }
        public List<Event> Events { get; set; }
        public List<Notification>? Notifications { get; set; }
        public ImageGallery ImageGallery { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Company()
        {
            Events = new List<Event>();
        }
    }
}
