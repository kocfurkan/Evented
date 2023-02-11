using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evented.Web.Controllers
{
    public class CommentController : Controller
    {
    

        private readonly IMapper mapper;
        private readonly UserManager<User> usrManager;
        public SignInManager<User> signInManager;
        private readonly ICommentService commentService;

        public CommentController(IMapper _IMapper, UserManager<User> _usrManager, SignInManager<User> _SignInManager, ICommentService _commentService)
        {
            mapper = _IMapper;
            usrManager = _usrManager;
            signInManager = _SignInManager;
            commentService = _commentService;
        }
        public async Task<IActionResult> Index()
        {
            List<Comment> comments = await commentService.GetAllCommentsAsync();
            return PartialView("_PartialPageComments", comments);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            Comment comment = await commentService.GetCommentAsync(id); 
            return View();
        }

  
        public ActionResult Create()
        {
            return PartialView("_PartialPageCreate");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentVM commentVM)
        {
            User usr= usrManager.GetUserAsync(User).Result;
           
            var comment = mapper.Map<Comment>(commentVM);
            comment.User = usr;

            commentService.AddCommentAsync(comment);
            return RedirectToAction("Index");
        }

      
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
