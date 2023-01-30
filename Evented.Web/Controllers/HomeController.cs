using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Evented.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Evented.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        public HomeController(ILogger<HomeController> logger, IEventService _eventService, IMapper _mapper )
        {
            eventService = _eventService;
            mapper = _mapper;
            _logger = logger;
        }

        public  IActionResult Index()
        {
            //Creator Name Should Be Passed to Index
            var events =  eventService.GetEventsConditional();
           
            var mapped = mapper.Map<List<EventVM>>(events);
            return View(mapped);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}