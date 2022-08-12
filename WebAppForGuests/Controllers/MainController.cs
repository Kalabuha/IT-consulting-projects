using Microsoft.AspNetCore.Mvc;
using WebAppForGuests.Models;
using Services.Interfaces;
using Services.Converters;
using Resources.Models;
using Resources.Datas;
using Resources.Enums;

namespace WebAppForGuests.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMainPageService _mainPageService;
        private readonly IApplicationService _applicationService;
        private readonly IHeaderService _headerService;


        public MainController(
            ILogger<MainController> logger,
            IMainPageService mainPageService,
            IApplicationService applicationService,
            IHeaderService headerService)
        {
            _logger = logger;
            _mainPageService = mainPageService;
            _applicationService = applicationService;
            _headerService = headerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new MainPageViewModel();

            var menuData = await _headerService.GetUsedMenuDataAsync();
            viewModel.PageH1 = menuData.Main;

            var mainPagePreset = await _mainPageService.GetPublishedPresetDataAsync();
            if (mainPagePreset != null)
            {
                var textData = await _mainPageService.GetElementDataByIdAsync<MainPageTextData>(mainPagePreset?.TextId);
                var imageData = await _mainPageService.GetElementDataByIdAsync<MainPageImageData>(mainPagePreset?.ImageId);
                var buttonData = await _mainPageService.GetElementDataByIdAsync<MainPageButtonData>(mainPagePreset?.ButtonId);
                var phraseData = await _mainPageService.GetElementDataByIdAsync<MainPagePhraseData>(mainPagePreset?.PhraseId);
                var actionData = await _mainPageService.GetElementDataByIdAsync<MainPageActionData>(mainPagePreset?.ActionId);

                if (textData != null) viewModel.TextModel = textData.TextDataToModel();
                viewModel.ImageModel = imageData?.ImageDataToModel();
                viewModel.ButtonModel = buttonData?.ButtonDataToModel();
                viewModel.PhraseModel = phraseData?.PhraseDataToModel();
                if (actionData != null) viewModel.ActionModel = actionData.ActionDataToModel();
            }

            viewModel.TextModel ??= (await _mainPageService.GetDefaultMainPageTextData()).TextDataToModel();
            viewModel.ActionModel ??= (await _mainPageService.GetDefaultMainPageActionData()).ActionDataToModel();

            viewModel.ApplicationModel = new ApplicationModel
            {
                Status = ApplicationStatus.Initial,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication(ApplicationModel application)
        {
            if (application == null)
            {
                return RedirectToAction(nameof(Index));
            }

            TrimApplicationModelData(application);

            var applicationId = await _applicationService.AddApplicationToDb(application);
            return RedirectToAction(nameof(MessageApplicationSent), new { applicationId });
        }

        [HttpGet]
        public async Task<IActionResult> MessageApplicationSent(int applicationId)
        {
            var application = await _applicationService.GetApplicationById(applicationId);
            return View(application);
        }

        private void TrimApplicationModelData(ApplicationModel application)
        {
            application.GuestEmail = application.GuestEmail?.Trim();
            application.GuestEmail = application.GuestEmail?.Trim();
            application.GuestApplicationText = application.GuestApplicationText?.Trim();
        }
    }
}