
using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService compService;
        private readonly IMapper mapper;
        private readonly UserManager<User> usrManager;
        public SignInManager<User> signInManager;
        public CompanyController(ICompanyService _compService, IMapper _IMapper, UserManager<User> _usrManager, SignInManager<User> _SignInManager)
        {
            compService = _compService;
            mapper = _IMapper;
            usrManager = _usrManager;
            signInManager = _SignInManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var companies = await compService.GetAllCompanysAsync();
            var mapped = mapper.Map<List<CompanyVM>>(companies);
            return View(mapped);
        }
        public async Task<IActionResult> MyCompanies()
        {
            string usrId = usrManager.GetUserId(User);
            var companies = await compService.GetUserCompanies(usrId);
            var mapped = mapper.Map<List<CompanyVM>>(companies);
            return View(mapped);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var usr = await usrManager.GetUserAsync(User);
            Company companyDetail = await compService.GetCompanyAsync(id);
          

            var mappedCompany = mapper.Map<CompanyVM>(companyDetail);

            return View(mappedCompany);
        }
        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyVM companyVM)
        {
            var usr = await usrManager.GetUserAsync(User);
            var mappedComp = mapper.Map<Company>(companyVM);
            mappedComp.OwnedBy = usr;
            mappedComp.CreatedAt=DateTime.Now;
            mappedComp.UpdatedAt=DateTime.Now;

            var result = await compService.AddCompanyAsync(mappedComp);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public IActionResult EditCompany()
        {
            return View();
        }

        public async Task<IActionResult> EditCompany(int id)
        {
            Company myCompany = await compService.GetCompanyAsync(id);
            var mappedCompany = mapper.Map<CompanyVM>(myCompany);
            return View(mappedCompany);
        }
        [HttpPost]
        public async Task<IActionResult> EditCompany(CompanyVM companyVM)
        {
            Company mycompany = mapper.Map<Company>(companyVM);
            var usr = usrManager.GetUserAsync(User);
            mycompany.OwnedBy = usr.Result;
            await compService.UpdateCompanyAsync(mycompany);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            Company myCompany = await compService.GetCompanyAsync(id);
            var mappedCompany = mapper.Map<CompanyVM>(myCompany);
            return View(mappedCompany);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCompany(Company myComp)
        {
            await compService.DeleteCompanyAsync(myComp.Id);
            return RedirectToAction("Index");
        }
    }
}
