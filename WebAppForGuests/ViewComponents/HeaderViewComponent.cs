using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using DataModelsWebModelsMappers;
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
            var menuData = await _headerService.GetUsedHeaderMenuDataAsync();
            var menuModel = menuData.MenuDataToModel();

            var sloganData = await _headerService.GetRandomOrDefaultHeaderSloganDataAsync();
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
