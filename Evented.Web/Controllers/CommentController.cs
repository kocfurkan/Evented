using AutoMapper;
using Evented.Domain.Contracts;
using Evented.Domain.Models;
using Evented.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Evented.Web.Controllers
{
    public class CommentController : Controller
    {
    

        private readonly IMapper mapper;
        private readonly UserManager<User> usrManager;
        public SignInManager<User> signInManager;
        private readonly ICommentService commentService;
        private readonly IEventService eventService;

        public CommentController(IMapper _IMapper, UserManager<User> _usrManager, SignInManager<User> _SignInManager, ICommentService _commentService, IEventService _eventService)
        {
            mapper = _IMapper;
            usrManager = _usrManager;
            signInManager = _SignInManager;
            commentService = _commentService;
            eventService =_eventService;
        }
        public async Task<IActionResult> Index(int EventId)
        {
           
            List<Comment> comments = await commentService.GetCommentsConditional(EventId);
            List<CommentVM> commentsList =  mapper.Map<List<CommentVM>>(comments).ToList();
            return PartialView("_PartialPageComments", commentsList);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            Comment comment = await commentService.GetCommentAsync(id); 
            return View();
        }

  
        public ActionResult Create(int EventId)
        {
            return PartialView("_PartialPageCreate", new CommentVM() { EventId = EventId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(CommentVM commentVM,int eventId)
        {

            User usr= usrManager.GetUserAsync(User).Result;

            var comment = mapper.Map<Comment>(commentVM);
            comment.EventId= eventId;
            comment.User = usr;
            comment.CreatedAt= DateTime.Now;
            comment.UpdatedAt= DateTime.Now;
        
            await commentService.AddCommentAsync(comment);
            return RedirectToAction("Detail","Event",new { id =eventId} );
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
