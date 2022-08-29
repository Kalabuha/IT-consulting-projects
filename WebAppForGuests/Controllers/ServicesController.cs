using Microsoft.AspNetCore.Mvc;
using WebAppForGuests.Models;
using WebServices.Interfaces;
using WebServices.Converters;

namespace WebAppForGuests.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IHeaderService _headerService;

        public ServicesController(IServiceService serviceService, IHeaderService headerService)
        {
            _serviceService = serviceService;
            _headerService = headerService;
        }

        // GET: ServicesController
        public async Task<ActionResult<ServicesViewModel>> Index()
        {
            var menuData = await _headerService.GetUsedMenuDataAsync();
            ViewBag.PageH1 = menuData.Services;

            var serviceDatas = await _serviceService.GetPublishedServiceDatasAsync();
            var serviceModels = serviceDatas.Select(s => s.ServiceDataToModel())
                .ToList();

            return View(new ServicesViewModel() { Services = serviceModels });
        }
    }
}
