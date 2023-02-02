using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Evented.Service;
using Evented.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class HireController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;
        private readonly UserManager<User> usrManager;
        public SignInManager<User> signInManager;
        private readonly ICompanyService compService;
        private readonly IHireService hireService;

        public HireController(IEventService _eventService, IMapper _IMapper, UserManager<User> _usrManager, SignInManager<User> _SignInManager, ICompanyService _compService, IHireService _hireService)
        {
            eventService = _eventService;
            mapper = _IMapper;
            usrManager = _usrManager;
            signInManager = _SignInManager;
            compService = _compService;
            hireService = _hireService;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["eventid"] = id;
            var companies = await compService.GetAllCompanysAsync();
            var mapped = mapper.Map<List<CompanyVM>>(companies);
            return View(mapped);
        }
        public async Task<IActionResult> HireDetail(int id)
        {

            var usr = await usrManager.GetUserAsync(User);

            Company companyDetail = await compService.GetCompanyAsync(id);

            var mappedCompany = mapper.Map<CompanyVM>(companyDetail);

            return View(mappedCompany);
        }
        [HttpPost]
        public async Task<IActionResult> HireNotification(int id)
        {
            string idstring = TempData["eventid"].ToString();
            TempData["eventid2"]=idstring;
            int id2 = Convert.ToInt32(idstring);
            string userid = usrManager.GetUserId(User);
            await hireService.HireNotification(id, id2, userid);
            return RedirectToAction("Index");
        }
        //AUTOMAP LIST OF ITEMS ? 

    
        [HttpPost]
        public async Task<IActionResult> HireAccept(int id)
        {
            string currentEventId = TempData["eventid2"].ToString();
            int id2 = Convert.ToInt32(currentEventId);
            await hireService.Hire(id, id2);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> HireReject(int id)
        {
            await hireService.HireReject(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Notifications()
        {
            string userid = usrManager.GetUserId(User);

            List<Notification> notifications = await hireService.GetNotifications(userid);

            return View(notifications);
        }
    }
}
