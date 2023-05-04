using BreckProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BreckProject1.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentRepository _commentRepository;
        private readonly IConfiguration configuration;

        public CommentController(IConfiguration configuration, CommentRepository commentRepository)
        {
            this.configuration = configuration;
            _commentRepository = commentRepository;
        }

        public ActionResult Index()
        {
            var comments = _commentRepository.GetAll();
            return View(comments);
        }
        public IActionResult AddComment(Comment comment)
        {
            _commentRepository.Add(comment);
            return RedirectToAction("Index");
        }
    }

}
