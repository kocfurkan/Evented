using AutoMapper;
using Evented.Application.Contracts;
using Evented.Common.ViewModels;
using Evented.Domain.Models;
using System.Threading.Tasks;
using Evented.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        private readonly UserManager<User> usrManager;
        public SignInManager<User> signInManager;
 

        public EventController(IEventService _eventService, IMapper _IMapper, UserManager<User> _usrManager, SignInManager<User> _SignInManager)
        {
            eventService = _eventService;
            mapper = _IMapper;
            usrManager = _usrManager;
            signInManager = _SignInManager;
        }
        public async Task<IActionResult> Index()
        {
         
            var user = usrManager.GetUserId(User);
            var model = eventService.GetUserEvents(user);
            var mapped= mapper.Map<List<EventVM>>(model);
            return View(mapped);
        }
        public  IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventVM eventVM)
        {
            var usr = usrManager.GetUserAsync(User) ;
            var mappedEvent = mapper.Map<Event>(eventVM);
            mappedEvent.IsValid = true;
            mappedEvent.CreatorUser = usr.Result;
            var result = await eventService.AddEventAsync(mappedEvent);
            if (result!= null)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
          
        }
    }
}
