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
    public class TagsController : ApiController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        // GET: api/Tags
        public async Task<IHttpActionResult> GetTags()
        {
            return Ok(await _tagService.GetAllAsync());
        }

        // GET: api/Tags/5
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> GetTag(Guid id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Tags/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> Update(Guid id, TagEditViewModels tagEditViewModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null)
            {
                return BadRequest();
            }

            tag.Name = tagEditViewModels.Name;
            tag.UrlSlug = tagEditViewModels.UrlSlug;
            tag.Description = tagEditViewModels.Description;

            var result = await _tagService.UpdateAsync(tag);
            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tags
        [ResponseType(typeof(Tag))]
        [HttpPost]
        public async Task<IHttpActionResult> Create(TagEditViewModels tagEditViewModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = new Tag()
            {
                Id = tagEditViewModels.Id,
                Name = tagEditViewModels.Name,
                UrlSlug = tagEditViewModels.UrlSlug,
                Description = tagEditViewModels.Description,
            };

            var result = await _tagService.AddAsync(tag);
            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var tagViewModels = new TagViewModels()
            {
                Id = tag.Id,
                Name = tag.Name,
                UrlSlug = tag.UrlSlug,
                Description = tag.Description,
                IsDeleted = tag.IsDeleted,
                InsertedAt = tag.InsertedAt,
                UpdatedAt = tag.UpdatedAt,
            };

            return CreatedAtRoute("DefaultApi", new { id = tag.Id }, tagViewModels);
        }

        // DELETE: api/Tags/5
        [ResponseType(typeof(Tag))]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            var result = await _tagService.DeleteAsync(tag);
            if (result)
            {
                return Ok(tag);
            }
            return BadRequest();
        }
    }
}