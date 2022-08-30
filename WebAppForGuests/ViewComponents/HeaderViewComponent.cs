using Microsoft.AspNetCore.Mvc;
using WebServices.Interfaces;
using DataModelsWebModelsConverters;
using WebAppForGuests.Models;

namespace WebAppForGuests.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHeaderService _headerService;

        public HeaderViewComponent(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuData = await _headerService.GetUsedMenuDataAsync();
            var menuModel = menuData.MenuDataToModel();

            var sloganData = await _headerService.GetRandomSloganDataAsync();
            var sloganModel = sloganData.SloganDataToModel();

            var viewModel = new HeaderViewModel()
            {
                Menu = menuModel,
                Slogan = sloganModel,
            };

            return View("Header", viewModel);
        }
    }
}
