using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using DataModels;

namespace WebAppDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/<BlogsController>
        [HttpGet]
        public async Task<ActionResult<List<BlogData>>> Get()
        {
            var blogs = await _blogService.GetAllBlogDatasAsync();

            return Ok(blogs);
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogData>> Get(int id)
        {
            var blog = await _blogService.GetBlogDataByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // POST api/<BlogsController>
        [HttpPost]
        public async Task<ActionResult> Post(BlogData blog)
        {
            await _blogService.AddBlogToDbAsync(blog);

            return Ok();
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(BlogData blog)
        {
            var editedBlog = await _blogService.GetBlogDataByIdAsync(blog.Id);
            if (editedBlog == null)
            {
                return NotFound();
            }


            await _blogService.EditBlogToDbAsync(blog);

            return Ok();
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedBlog = await _blogService.GetBlogDataByIdAsync(id);
            if (deletedBlog == null)
            {
                return NotFound();
            }

            await _blogService.RemoveBlogToDbAsync(id);

            return Ok();
        }
    }
}
