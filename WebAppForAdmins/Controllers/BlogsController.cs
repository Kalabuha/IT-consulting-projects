using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAppForAdmins.Models.Blogs;
using WebServices.Interfaces;
using DataModelsWebModelsConverters;
using WebModels;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Senior, Admin")]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _blogService.GetAllBlogDatasAsync();
            var models = datas.Select(b => b.BlogDataToModel())
                .ToList();

            var viewModel = new BlogsViewModel
            {
                Blogs = models
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BlogModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(BlogModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var data = model.BlogModelToData();
            await _blogService.AddBlogToDbAsync(data);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsImageRemovalAvailable = true;

            var data = await _blogService.GetBlogDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.BlogDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(BlogModel model)
        {
            ViewBag.IsImageRemovalAvailable = true;

            var oldData = await _blogService.GetBlogDataByIdAsync(model.Id);
            if (oldData == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var oldModel = oldData.BlogDataToModel();
                model.BlogImageAsString = oldModel.BlogImageAsString;
                return View("Edit", model);
            }

            var newData = model.BlogModelToData();
            if (model.IsRemoveImage)
            {
                newData.BlogImageAsString = null;
            }
            else if (newData.BlogImageAsString == null)
            {
                newData.BlogImageAsString = string.Empty;
            }

            await _blogService.EditBlogToDbAsync(newData);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.IsChangeDisabled = true;

            var data = await _blogService.GetBlogDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.BlogDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(BlogModel model)
        {
            await _blogService.RemoveBlogToDbAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
