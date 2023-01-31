using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Evented.Service;
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
        public IActionResult Hire(int id)
        {
          string idstring = TempData["eventid"].ToString();
          int id2 = Convert.ToInt32(idstring);
          hireService.Hire(id,id2);
          return RedirectToAction("Index");
        }

    }
}
