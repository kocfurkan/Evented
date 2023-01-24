using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    [Authorize]
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
            var model = await eventService.GetUserEvents(user);
            var mapped = mapper.Map<List<EventVM>>(model);
            return View(mapped);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Event myevent = await eventService.GetEventAsync(id);
            var mappedevent = mapper.Map<EventVM>(myevent);
            return View(mappedevent);
        }

        //SQL EXCEPTION ON VIEW?
        [HttpPost]
        public async Task<IActionResult> JoinEvent(EventVM events)
        {
            Event myevent = mapper.Map<Event>(events);
            var usr = usrManager.GetUserAsync(User);
            int count = myevent.UserJoined.Count;
            int? joineeNumber = myevent.joineeNumber;
            if (myevent.joineeLimit > myevent.joineeNumber)
            {
                if (myevent.UserJoined.Count != 0)
                {
                    foreach (var user in myevent.UserJoined)
                    {
                        if (user.Id != usr.Result.Id)
                        {
                            myevent.UserJoined.Add(usr.Result);
                        }
                        else { ModelState.AddModelError(nameof(events.Id), "You Have Already Joined The Event"); }
                    }
                }
                else
                {
                    myevent.UserJoined.Add(usr.Result);
                }
            }
            else { ModelState.AddModelError(nameof(events.Id), "Event Is Full"); }

            myevent.joineeNumber = ++joineeNumber;
            await eventService.UpdateEventAsync(myevent);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> LeaveEvent(EventVM myEvent)
        {
            Event myevent = mapper.Map<Event>(myEvent);
           
            var usr = usrManager.GetUserAsync(User);
            int? joineeNumber = myEvent.joineeNumber;

            
            myevent.UserJoined.Remove(usr.Result);
            usr.Result.EventJoined.Remove(myevent);
            myevent.joineeNumber = --joineeNumber;
            await eventService.UpdateEventAsync(myevent);
            return RedirectToAction("Index");  
        }
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventVM eventVM)
        {
            var usr = usrManager.GetUserAsync(User);
            var mappedEvent = mapper.Map<Event>(eventVM);
            mappedEvent.IsValid = true;
            mappedEvent.CreatorUser = usr.Result;
            var result = await eventService.AddEventAsync(mappedEvent);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public async Task<IActionResult> EditEvent(int id)
        {
            Event myevent = await eventService.GetEventAsync(id);
            var mappedevent = mapper.Map<EventVM>(myevent);
            return View(mappedevent);
        }
        [HttpPost]
        public async Task<IActionResult> EditEvent(EventVM eventVM)
        {
            Event myevent = mapper.Map<Event>(eventVM);
            var usr = usrManager.GetUserAsync(User);
            myevent.CreatorUser = usr.Result;
            await eventService.UpdateEventAsync(myevent);
            return RedirectToAction("Index");
        }
        //VIEW NOT ADDED
        public async Task<IActionResult> DeleteEvent(int id)
        {
            Event myevent = await eventService.GetEventAsync(id);
            var usr = usrManager.GetUserAsync(User);
            myevent.CreatorUser = usr.Result;

            var mappedevent = mapper.Map<EventVM>(myevent);
            return View(mappedevent);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEvent(Event myevent)
        {
            await eventService.DeleteEventAsync(myevent.Id);
            return RedirectToAction("Index");
        }
    }

}
