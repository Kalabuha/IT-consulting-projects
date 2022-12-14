using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppForAdmins.Models.Services;
using ServiceInterfaces;
using DataModelsWebModelsMappers;
using WebModels;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Senior, Admin")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _serviceService.GetAllServiceDatasAsync();
            var models = datas.Select(s => s.ServiceDataToModel())
                .ToList();

            var viewModel = new ServicesViewModel()
            {
                Services = models
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.IsChangeDisabled = false;

            return View(new ServiceWebModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(ServiceWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create), model);
            }

            var data = model.ServiceModelToData();
            await _serviceService.AddServiceToDbAsync(data);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsChangeDisabled = false;

            var data = await _serviceService.GetServiceDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ServiceDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(ServiceWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var data = model.ServiceModelToData();
            await _serviceService.EditServiceToDbAsync(data);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.IsChangeDisabled = true;

            var data = await _serviceService.GetServiceDataByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = data.ServiceDataToModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _serviceService.RemoveServiceToDbAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
