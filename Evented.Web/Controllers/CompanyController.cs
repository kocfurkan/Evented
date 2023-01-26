
using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
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
        public Task<IActionResult> Index()
        {

            return View("Index");
        }
    }
}
