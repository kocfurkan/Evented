using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Data.Models
{
    public class ImageGallery:IBaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Image> Image { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
   
    }
}
