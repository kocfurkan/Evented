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
        // GET: CommentController

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

        // GET: CommentController/Details/5
        public async Task<IActionResult> DetailsAsync(int id)
        {
            Comment comment = await commentService.GetCommentAsync(id); 
            return View();
        }

        // GET: CommentController/Create
        public ActionResult Create()
        {
            return PartialView("_PartialPageCreate");
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            commentService.AddCommentAsync(comment);
            return View();
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
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

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
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
