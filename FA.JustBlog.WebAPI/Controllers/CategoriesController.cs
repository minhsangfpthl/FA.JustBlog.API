using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebAPI.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FA.JustBlog.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/Categories
        public async Task<IHttpActionResult> GetCategories()
        {
            return Ok( await _categoryService.GetAllAsync());
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(Guid id, CategoryEditViewModels categoryEditViewModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return BadRequest();
            }

            category.Name = categoryEditViewModels.Name;
            category.UrlSlug = categoryEditViewModels.UrlSlug;
            category.Description = categoryEditViewModels.Description;

            var result = await _categoryService.UpdateAsync(category);
            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(CategoryEditViewModels categoryEditViewModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category()
            {
                Id = categoryEditViewModels.Id,
                Name = categoryEditViewModels.Name,
                UrlSlug = categoryEditViewModels.UrlSlug,
                Description = categoryEditViewModels.Description,
            };

            var result = await _categoryService.AddAsync(category);
            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var categoryViewModel = new CategoryViewModels
            {
                Id = category.Id,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Description = category.Description,
                IsDeleted = category.IsDeleted,
                InsertedAt = category.InsertedAt,
                UpdatedAt = category.UpdatedAt,
            };

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, categoryViewModel);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var result = await _categoryService.DeleteAsync(category);
            if (result)
            {
                return Ok(category);
            }
            return BadRequest();
        }
    }
}