using AutoMapper;

using Evented.Domain.Models;
using Evented.Web.ViewModels;

namespace Evented.Web
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Event, EventVM>().ReverseMap();
            CreateMap<Company, CompanyVM>().ReverseMap();
            CreateMap<Event, EventVMCompany>().ReverseMap();
            CreateMap<Notification,NotificationVM>().ReverseMap();
        }
    }
}
