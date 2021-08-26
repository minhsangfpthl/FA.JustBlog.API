using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebMVC.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postServices;
        private readonly ICategoryService _categoryServices;

        public HomeController(IPostService postServices, ICategoryService categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }
        public async Task<ActionResult> Index(int? pageIndex = 1, int? pageSize = 5)
        {
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = x => x.OrderByDescending(p => p.PublishedDate);
            var posts = await _postServices.GetAsync(filter: null, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize ?? 5);
            return View(posts);
        }

        public ActionResult Menu()
        {
            var categories = _categoryServices.GetAll();
            var popularCategories = categories.OrderByDescending(x => x.Posts.Count).Take(4);
            var leftCategories = categories.OrderByDescending(x => x.Posts.Count).Skip(4);
            var categoryMenuViewModel = new CategoryMenuViewModel()
            {
                PopularCategory = popularCategories,
                leftCategories = leftCategories
            };
            return PartialView("_Menu", categoryMenuViewModel);
        }
        public ActionResult PostSlider()
        {
            var posts = _postServices.GetMostViewedPost(4);
            return PartialView("_PostSlider", posts);
        }


        public ActionResult About()
        {
            ViewData["Message"] = "Hello FA.JustBlog";
            ViewBag.Message = "Hello FA.JustBlog";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}