using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FA.JustBlog.WebAPI.Controllers
{
    public class PostsController : ApiController
    {
        private readonly ICategoryService _categoryServices;
        private readonly IPostService _postServices;

        public PostsController(ICategoryService categoryServices, IPostService postServices)
        {
            _categoryServices = categoryServices;
            _postServices = postServices;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _postServices.GetAllAsync());
        }

        // GET: api/Posts/5
        [HttpGet]
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        [HttpPut]
        /*     public async Task<IHttpActionResult> Update(Guid id, PostEditViewModels postEditViewModels)
             {
                 if (!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }

                 if (id != postEditViewModels.Id)
                 {
                     return BadRequest();
                 }

                 db.Entry(post).State = EntityState.Modified;

                 try
                 {
                     await db.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!PostExists(id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }

                 return StatusCode(HttpStatusCode.NoContent);
    }*/

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        [HttpPost]
        /*     public async Task<IHttpActionResult> Create(PostEditViewModels postEditViewModels)
             {
                 if (!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }

                 db.Posts.Add(post);

                 try
                 {
                     await db.SaveChangesAsync();
                 }
                 catch (DbUpdateException)
                 {
                     if (PostExists(post.Id))
                     {
                         return Conflict();
                     }
                     else
                     {
                         throw;
                     }
                 }

                 return CreatedAtRoute("DefaultApi", new { id = post.Id }, post); 
    }
        */
        // DELETE: api/Posts/5
        [ResponseType(typeof(bool))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePost(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                NotFound();
            }
            var result = await _postServices.DeleteAsync(post);

            if (result)
            {
                return Ok(true);
            }
            return BadRequest();
        }
    }
}