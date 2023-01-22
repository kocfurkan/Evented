
using System.ComponentModel.DataAnnotations;

namespace Evented.Web
{
    public class EventVM
    {
        public string Topic { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(250)]
        public string Description { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }
        public DateTime BeginsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public int joineeLimit { get; set; }
    }
}
