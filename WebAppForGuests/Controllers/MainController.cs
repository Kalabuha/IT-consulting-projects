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
            var menuData = await _headerService.GetUsedMenuDataAsync();
            ViewBag.PageH1 = menuData.Main;

            var viewModel = new MainPageViewModel();

            var mainPagePreset = await _mainPageService.GetPublishedPresetDataAsync();
            if (mainPagePreset != null)
            {
                var textData = await _mainPageService.GetElementDataByIdAsync<MainPageTextData>(mainPagePreset?.TextId);
                viewModel.Text = textData?.TextDataToModel();

                var imageData = await _mainPageService.GetElementDataByIdAsync<MainPageImageData>(mainPagePreset?.ImageId);
                viewModel.Image = imageData?.ImageDataToModel();

                var buttonData = await _mainPageService.GetElementDataByIdAsync<MainPageButtonData>(mainPagePreset?.ButtonId);
                viewModel.Button = buttonData?.ButtonDataToModel();

                var phraseData = await _mainPageService.GetElementDataByIdAsync<MainPagePhraseData>(mainPagePreset?.PhraseId);
                viewModel.Phrase = phraseData?.PhraseDataToModel();

                var actionData = await _mainPageService.GetElementDataByIdAsync<MainPageActionData>(mainPagePreset?.ActionId);
                viewModel.Action = actionData?.ActionDataToModel();
            }

            viewModel.Text ??= await _mainPageService.GetDefaultMainPageTextData();
            viewModel.Action ??= await _mainPageService.GetDefaultMainPageActionData();

            viewModel.Application = new ApplicationModel
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
            var application = await _applicationService.GetApplicationByID(applicationId);
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