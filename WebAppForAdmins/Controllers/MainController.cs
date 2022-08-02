using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppForAdmins.Models;
using Services.Interfaces;
using Resources.Models;
using Resources.Datas;
using Services.Converters;

namespace WebAppForAdmins.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMainPageService _mainPageService;

        public MainController(ILogger<MainController> logger, IMainPageService mainPageService)
        {
            _logger = logger;
            _mainPageService = mainPageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var presetDatas = await _mainPageService.GetAllPresetDatasAsync();
            var presetModels = presetDatas.Select(p => p.MainPagePresetDataToModel())
                .ToList();

            MainPagePresetData? selectedPresetData;
            if (id.HasValue && id.Value > 0)
            {
                selectedPresetData = await _mainPageService.GetPresetDataByIdAsync(id.Value);
            }
            else
            {
                selectedPresetData = await _mainPageService.GetPublishedPresetDataAsync();
            }

            var selectedPresetModel = selectedPresetData?.MainPagePresetDataToModel();

            var viewModel = new MainViewModel
            {
                SelectedPreset = selectedPresetModel,
                Presets = presetModels,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SelectPreset(int id)
        {
            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> PublishSelectedPreset(int id)
        {
            if (id > 0)
            {
                await _mainPageService.PublishPreset(id);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelectedPreset(int id)
        {
            if (id > 0)
            {
                var data = await _mainPageService.GetPresetDataByIdAsync(id);
                if (data == null)
                {
                    return NotFound();
                }

                await _mainPageService.DeletePreset(data);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePreset(MainPagePresetModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }

            var data = model.MainPagePresetModelToData();
            var id = await _mainPageService.CreatePreset(data);

            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> ActionBlock(int id)
        {
            var viewModel = await GetActionSelectViewModelAsync(id);

            return PartialView(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ImageBlock(int id)
        {
            var viewModel = await GetImageBlockViewModelAsync(id);

            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectButtonForCurrentPreset(MainPageButtonModel model, int id)
        {
            ViewBag.PresetId = id;

            var preset = await _mainPageService.GetPresetDataByIdAsync(id);
            var buttonData = await _mainPageService.GetElementDataByIdAsync<MainPageButtonData>(model.Id);

            if (preset != null && buttonData != null)
            {
                preset.ButtonId = buttonData.Id;
                await _mainPageService.UpdatePreset(preset);
            }

            return PartialView(buttonData);
        }

        [HttpGet]
        public async Task<IActionResult> TextBlock(int id)
        {
            var viewModel = await GetTextSelectViewModelAsync(id);

            return PartialView(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> SelectTextForCurrentPreset(int id, int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
            var textData = await _mainPageService.GetElementDataByIdAsync<MainPageTextData>(id);

            if (presetData != null && textData != null)
            {
                presetData.TextId = textData.Id;
                await _mainPageService.UpdatePreset(presetData);
            }

            var viewModel = await GetTextSelectViewModelAsync(presetId);

            return PartialView(viewModel);
        }








        private async Task<TextSelectViewModel> GetTextSelectViewModelAsync(int presetId)
        {
            var textSelectViewModel = new TextSelectViewModel();

            if (presetId > 0)
            {
                var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
                if (presetData != null && presetData.TextId.HasValue)
                {
                    textSelectViewModel.CurrentPresetId = presetId;
                    textSelectViewModel.SelectedTextId = presetData.TextId.Value;
                }

                var textDatas = await _mainPageService.GetAllElementDatasAsync<MainPageTextData>();
                var textModels = textDatas.Select(t => t.TextDataToModel())
                    .ToList();

                textSelectViewModel.Texts = textModels;
            }
            else
            {
                var defaultMainPageTextData = await _mainPageService.GetDefaultMainPageTextData();
                var defaultMainPageTextModel = defaultMainPageTextData.TextDataToModel();

                textSelectViewModel.SelectedTextId = 0;
                textSelectViewModel.CurrentPresetId = 0;

                textSelectViewModel.Texts = new List<MainPageTextModel> { defaultMainPageTextModel };
            }

            return textSelectViewModel;
        }

        private async Task<ImageBlockViewModel> GetImageBlockViewModelAsync(int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
            if (presetData == null)
            {
                return new ImageBlockViewModel();
            }

            var allImageDatas = await _mainPageService.GetAllElementDatasAsync<MainPageImageData>();
            var allImageModels = allImageDatas.Select(i => i.ImageDataToModel()).ToList();
            var imageSelectViewModel = new ImageSelectViewModel
            {
                CurrentPresetId = presetId,
                SelectedImageId = presetData.ImageId.HasValue ? presetData.ImageId.Value : 0,
                Images = allImageModels,
            };

            var allButtonDatas = await _mainPageService.GetAllElementDatasAsync<MainPageButtonData>();
            var allButtonModels = allButtonDatas.Select(b => b.ButtonDataToModel()).ToList();
            var buttonSelectViewModel = new ButtonSelectViewModel
            {
                CurrentPresetId = presetId,
                SelectedButtonId = presetData.ButtonId.HasValue ? presetData.ButtonId.Value : 0,
                Buttons = allButtonModels,
            };

            var allPhraseDatas = await _mainPageService.GetAllElementDatasAsync<MainPagePhraseData>();
            var allPhraseModels = allPhraseDatas.Select(p => p.PhraseDataToModel()).ToList();
            var phraseSelectViewModel = new PhraseSelectViewModel
            {
                CurrentPresetId = presetId,
                SelectedPhraseId = presetData.PhraseId.HasValue ? presetData.PhraseId.Value : 0,
                Phrases = allPhraseModels,
            };

            var viewModel = new ImageBlockViewModel
            {
                ImageSelectViewModel = imageSelectViewModel,
                ButtonSelectViewModel = buttonSelectViewModel,
                PhraseSelectViewModel = phraseSelectViewModel,
            };

            return viewModel;
        }

        private async Task<ActionSelectViewModel> GetActionSelectViewModelAsync(int presetId)
        {
            var actionSelectViewModel = new ActionSelectViewModel();

            if (presetId > 0)
            {
                var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
                if (presetData != null && presetData.ActionId.HasValue)
                {
                    actionSelectViewModel.CurrentPresetId = presetId;
                    actionSelectViewModel.SelectedActionId = presetData.ActionId.Value;
                }

                var actionDatas = await _mainPageService.GetAllElementDatasAsync<MainPageActionData>();
                var actionModels = actionDatas.Select(a => a.ActionDataToModel())
                    .ToList();

                actionSelectViewModel.Actions = actionModels;
            }
            else
            {
                var defaultMainPageActionData = await _mainPageService.GetDefaultMainPageActionData();
                var defaultMainPageActionModel = defaultMainPageActionData.ActionDataToModel();

                actionSelectViewModel.SelectedActionId = 0;
                actionSelectViewModel.CurrentPresetId = 0;

                actionSelectViewModel.Actions = new List<MainPageActionModel> { defaultMainPageActionModel };
            }

            return actionSelectViewModel;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}