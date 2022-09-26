using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces;
using DataModelsWebModelsMappers;
using WebAppForGuests.Models;

namespace WebAppForGuests.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHeaderService _headerService;
        
        private readonly string _startPathToDefaultData;

        public HeaderViewComponent(IHeaderService headerService)
        {
            _startPathToDefaultData = @"..\DefaultDataServices\DefaultData\txt";
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuData = await _headerService.GetUsedOrDefaultHeaderMenuDataAsync();
            var menuModel = menuData.MenuDataToModel();

            var sloganData = await _headerService.GetRandomOrDefaultHeaderSloganDataAsync(_startPathToDefaultData);
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
