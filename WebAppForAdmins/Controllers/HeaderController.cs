using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppForAdmins.Models.Header;
using ServiceInterfaces;
using DataModelsWebModelsMappers;
using WebModels;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;

        public HeaderController(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menuData = await _headerService.GetUsedHeaderMenuDataAsync();
            var sloganData = await _headerService.GetRandomOrDefaultHeaderSloganDataAsync();

            var menuModel = menuData.MenuDataToModel();
            var sloganModel = sloganData.SloganDataToModel();

            var viewModel = new HeaderViewModel
            {
                UsedMenu = menuModel,
                RandomSlogan = sloganModel
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CustomizeMenu()
        {
            var allMenuDatas = await _headerService.GetAllHeaderMenuDatasAsync();
            var allMenuModels = allMenuDatas.Select(m => m.MenuDataToModel())
                .ToList();

            var viewModel = new MenuViewModel()
            {
                Menus = allMenuModels,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectMenu(int id)
        {
            if (id > 0)
            {
                await _headerService.StartUsingHeaderMenuAsync(id);
            }

            return RedirectToAction(nameof(CustomizeMenu));
        }

        [HttpGet]
        public IActionResult CreateMenu()
        {
            var menuModel = new HeaderMenuWebModel();

            return View(menuModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuPost(HeaderMenuWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CreateMenu), model);
            }

            var data = model.MenuModelToData();
            await _headerService.AddMenuToDbAsync(data);

            return RedirectToAction(nameof(CustomizeMenu));
        }

        [HttpGet]
        public async Task<IActionResult> EditUsedMenu()
        {
            var data = await _headerService.GetUsedHeaderMenuDataAsync();
            if (data.Id > 0)
            {
                var model = data.MenuDataToModel();
                return View(model);
            }

            return RedirectToAction(nameof(CustomizeMenu));
        }

        [HttpPost]
        public async Task<IActionResult> EditUsedMenuPost(HeaderMenuWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CreateMenu), model);
            }

            var data = model.MenuModelToData();
            await _headerService.EditMenuToDbAsync(data);

            return RedirectToAction(nameof(CustomizeMenu));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsedMenuPost()
        {
            var data = await _headerService.GetUsedHeaderMenuDataAsync();
            if (data.Id > 0)
            {
                await _headerService.RemoveMenuToDbAsync(data.Id);
            }

            return RedirectToAction(nameof(CustomizeMenu));
        }

        [HttpGet]
        public async Task<IActionResult> CustomizeSlogan()
        {
            var allSloganDatas = await _headerService.GetAllHeaderSloganDatasAsync();
            var allSloganModels = allSloganDatas.Select(s => s.SloganDataToModel())
                .ToList();

            var defaultSloganContent = await _headerService.GetDefaultSloganContent();

            var viewModel = new SloganViewModel
            {
                DefaultSloganContent = defaultSloganContent,
                Slogans = allSloganModels
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectSlogans(int[] id)
        {
            await _headerService.StartUsingHeaderSlogansAsync(id);

            return RedirectToAction(nameof(CustomizeSlogan));
        }

        [HttpGet]
        public IActionResult CreateSlogan()
        {
            var sloganModel = new HeaderSloganWebModel();

            return View(sloganModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSloganPost(HeaderSloganWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CreateSlogan), model);
            }

            var data = model.SloganModelToData();
            await _headerService.AddSloganToDbAsync(data);

            return RedirectToAction(nameof(CustomizeSlogan));
        }

        [HttpGet]
        public async Task<IActionResult> EditSlogan(int id)
        {
            var data = await _headerService.GetHeaderSloganDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.SloganDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSloganPost(HeaderSloganWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(EditSlogan), model);
            }

            var data = model.SloganModelToData();
            await _headerService.EditSloganToDbAsync(data);

            return RedirectToAction(nameof(CustomizeSlogan));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSlogan(int id)
        {
            ViewBag.IsChangeDisabled = true;

            var data = await _headerService.GetHeaderSloganDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.SloganDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSloganPost(HeaderSloganWebModel model)
        {
            var data = await _headerService.GetHeaderSloganDataByIdAsync(model.Id);
            if (data != null)
            {
                await _headerService.RemoveSloganToDbAsync(data.Id);
            }

            return RedirectToAction(nameof(CustomizeSlogan));
        }
    }
}
