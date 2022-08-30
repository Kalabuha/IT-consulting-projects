using Microsoft.AspNetCore.Mvc;
using WebAppForGuests.Models;
using WebServices.Interfaces;
using DataModelsWebModelsConverters;

namespace WebAppForGuests.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IHeaderService _headerService;

        public BlogsController(IBlogService blogService, IHeaderService headerService)
        {
            _blogService = blogService;
            _headerService = headerService;
        }

        [HttpGet]
        public async Task<ActionResult<BlogsViewModel>> Index()
        {
            var menuData = await _headerService.GetUsedMenuDataAsync();
            ViewBag.PageH1 = menuData.Blogs;

            var blogDatas = await _blogService.GetPublishedBlogDatasAsync();
            var blogModels = blogDatas.Select(b => b.BlogDataToModel())
                .ToList();

            return View(new BlogsViewModel { Blogs = blogModels });
        }

        [HttpGet]
        public async Task<ActionResult<BlogsViewModel>> BlogDetails(int id)
        {
            var data = await _blogService.GetBlogDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.BlogDataToModel();

            return View(new BlogsViewModel { SelectedBlog = model });
        }
    }
}
