using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebMVC.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        //private readonly PostsController : Controller;
        public PostsController(IPostService postService, ICategoryService categoryService, ICommentService commentService)
        {
            _commentService = commentService;
            _postService = postService;
            _categoryService = categoryService;
        }
        
        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var allPosts = await _postService.GetAllAsync();
            return View(allPosts);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postService.GetLatestPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Lastest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public ActionResult MostViewPosts()
        {
            var lastestPosts = Task.Run(() => _postService.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Most View Posts";
            return PartialView("_PopularPosts", lastestPosts);
        }

        public ActionResult HighestPosts()
        {
            var lastestPosts = Task.Run(() => _postService.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Highest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public async Task<ActionResult> Details(int year, int month, string urlSlug)
        {
            var post = await _postService.FindPostAsync(year, month, urlSlug);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostTitle = post.Title;
            ViewBag.PublishedDate = ConvertTimePublished(post.PublishedDate);
            return View(post);
        }

        public string ConvertTimePublished(DateTime publishedDate)
        {
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day;

            var time = new TimeSpan(DateTime.Now.Ticks - publishedDate.Ticks);
            double interval = Math.Abs(time.TotalSeconds);

            if (interval < 1 * minute)
            {
                return time.Seconds == 1 ? "one second ago" : time.Seconds + " seconds ago";
            }

            if (interval < 59 * minute)
            {
                return time.Minutes == 1 ? "one minute ago" : time.Minutes + " minutes ago";
            }

            if (interval < 24 * hour)
            {
                return time.Hours == 1 ? "an hour ago" : time.Hours + " hours ago";
            }

            if (interval < 30 * day)
            {
                return time.Days == 1 ? "one day ago" : time.Days + " days ago";
            }

            if (interval < 12 * month)
            {
                int months = Convert.ToInt32(Math.Floor((double)time.Days / 30));
                return months == 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)time.Days / 365));
                return years == 1 ? "one year ago" : years + " years ago";
            }
        }

        public async Task<ActionResult> Comment(CommentCreateViewModel commentCreateViewModel)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Name = commentCreateViewModel.Name,
                Email = commentCreateViewModel.Email,
                CommentHeader = commentCreateViewModel.CommentHeader,
                CommentText = commentCreateViewModel.CommentText,
                PostId = commentCreateViewModel.PostId
            };
            var result = await _commentService.AddAsync(comment);
            if (result < 0)
            {
                return Json(new { errorMess = "Create comment failed" });
            }
            var commentViewModel = new CommentViewModel()
            {
                Id = comment.Id,
                Name = commentCreateViewModel.Name,
                Email = commentCreateViewModel.Email,
                CommentHeader = commentCreateViewModel.CommentHeader,
                CommentText = commentCreateViewModel.CommentText,
                PostId = commentCreateViewModel.PostId,
                CommentTime = comment.CommentTime.ToString("MMM dd yyyy")
            };
            return Json(commentViewModel);
        }
    }
}