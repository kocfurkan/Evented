
using Evented.Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Evented.Web
{
    public class EventVMCompany
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Topic { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(250)]
        public string Description { get; set; }
        [Required, StringLength(200)]
        public string Location { get; set; }
        public bool IsValid { get; set; } = true;
        [DisplayName("Begins At")]
        public DateTime BeginsAt { get; set; }
        [DisplayName("Ends At")]
        public DateTime EndsAt { get; set; }
        [DisplayName("Participant Limit")]
        public int joineeLimit { get; set; }
        public int? joineeNumber { get; set; } 
        public string CreatorId { get; set; }
        public User CreatorUser { get; set; }
        public ICollection<UserEvent> UsersJoined { get; set; }
        public int? HiredCompanyId { get; set; }
        public Company? HiredCompany { get; set; }
        public ImageGallery? ImageGallery { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
