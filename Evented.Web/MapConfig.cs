using AutoMapper;

using Evented.Domain.Models;

namespace Evented.Web
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Event, EventVM>().ReverseMap();
            CreateMap<Company, CompanyVM>().ReverseMap();
            CreateMap<Event, EventVMCompany>().ReverseMap();

        }
    }
}
