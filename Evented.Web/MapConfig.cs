using AutoMapper;
using Evented.Common.ViewModels;
using Evented.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Event,EventVM>().ReverseMap();

        }
    }
}
