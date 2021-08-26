using FA.JustBlog.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagService _tagServices;
        private readonly IPostService _postServices;

        public TagsController(ITagService tagServices, IPostService postServices)
        {
            _tagServices = tagServices;
            _postServices = postServices;
        }

        public async Task<ActionResult> Details(string urlSlug)
        {
            var tag = await _tagServices.GetTagByUrlSlugAsync(urlSlug);
            var posts = await _postServices.GetPostsByTagAsync(tag.Id);
            ViewBag.TagName = tag.Name;
            return View(posts);
        }

        public ActionResult PopularTags()
        {
            var popularTags = Task.Run(() => _tagServices.GetPopularTags()).Result;
            return PartialView("_PopularTags", popularTags);
        }
    }
}