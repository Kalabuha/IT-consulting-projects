using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppForAdmins.Models;
using Services.Interfaces;
using Resources.Models;
using Resources.Datas;
using Services.Converters;
using WebAppForAdmins.Models.Main;

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

        #region Контроллеры пресетов
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
                await _mainPageService.PublishPresetAsync(id);
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

                await _mainPageService.DeletePresetAsync(data);
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
            var id = await _mainPageService.CreatePresetAsync(data);

            return RedirectToAction(nameof(Index), new { id });
        }
        #endregion

        #region Текстовый блок (TextBlock)
        [HttpGet]
        public async Task<IActionResult> TextBlock(int id)
        {
            var viewModel = await GetTextBlockViewModelAsync(id);
            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectTextForCurrentPreset(TextForCurrentPresetModel model)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(model.CurrentPresetId);
            if (presetData != null)
            {
                var textData = await _mainPageService.GetElementDataByIdAsync<MainPageTextData>(model.SelectedTextId);
                if (textData != null)
                {
                    presetData.TextId = textData.Id;
                    await _mainPageService.UpdatePresetAsync(presetData);
                }
            }

            var viewModel = await GetTextBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(TextBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTextForCurrentPreset(int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);

            if (presetData != null)
            {
                presetData.TextId = null;
                await _mainPageService.UpdatePresetAsync(presetData);
            }

            var viewModel = await GetTextBlockViewModelAsync(presetId);

            return PartialView(nameof(TextBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateText(CreateTextModel model)
        {
            if (!(string.IsNullOrEmpty(model.TextContent) || string.IsNullOrWhiteSpace(model.TextContent)))
            {
                model.TextContent = model.TextContent.Trim();
                if (model.TextContent.Length <= 4000)
                {
                    var textData = new MainPageTextData()
                    {
                        Text = model.TextContent!
                    };

                    await _mainPageService.CreateElementAsync(textData);
                }
            }

            var viewModel = await GetTextBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(TextBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteText(TextForCurrentPresetModel model)
        {
            if (model.SelectedTextId > 0)
            {
                await _mainPageService.DeleteElementAsync<MainPageTextData>(model.SelectedTextId);
            }

            var viewModel = await GetTextBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(TextBlock), viewModel);
        }
        #endregion

        #region Блок изображения (ImageBlock)
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
                await _mainPageService.UpdatePresetAsync(preset);
            }

            return PartialView(buttonData);
        }
        #endregion

        #region Блок с призывом к действию (ActionBlock)
        [HttpGet]
        public async Task<IActionResult> ActionBlock(int id)
        {
            var viewModel = await GetActionBlockViewModelAsync(id);

            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SelectActionForCurrentPreset(ActionForCurrentPresetModel model)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(model.CurrentPresetId);
            if (presetData != null)
            {
                var actionData = await _mainPageService.GetElementDataByIdAsync<MainPageActionData>(model.SelectedActionId);
                if (actionData != null)
                {
                    presetData.ActionId = actionData.Id;
                    await _mainPageService.UpdatePresetAsync(presetData);
                }
            }

            var viewModel = await GetActionBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ActionBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveActionForCurrentPreset(int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
            if (presetData != null)
            {
                presetData.ActionId = null;
                await _mainPageService.UpdatePresetAsync(presetData);
            }

            var viewModel = await GetActionBlockViewModelAsync(presetId);
            return PartialView(nameof(ActionBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAction(CreateActionModel model)
        {
            if (!(string.IsNullOrEmpty(model.ActionContent) || string.IsNullOrWhiteSpace(model.ActionContent)))
            {
                model.ActionContent = model.ActionContent.Trim();
                if (model.ActionContent.Length <= 60)
                {
                    var actionData = new MainPageActionData()
                    {
                        Action = model.ActionContent!
                    };

                    await _mainPageService.CreateElementAsync(actionData);
                }
            }

            var viewModel = await GetActionBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ActionBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAction(ActionForCurrentPresetModel model)
        {
            if (model.SelectedActionId > 0)
            {
                await _mainPageService.DeleteElementAsync<MainPageActionData>(model.SelectedActionId);
            }

            var viewModel = await GetActionBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ActionBlock), viewModel);
        }
        #endregion

        #region Получение моделей для блоков текста, изображения и призвыа к действию
        private async Task<TextBlockViewModel> GetTextBlockViewModelAsync(int presetId)
        {
            var textSelectViewModel = new TextBlockViewModel();

            if (presetId > 0)
            {
                var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
                if (presetData != null)
                {
                    var textDatas = await _mainPageService.GetAllElementDatasAsync<MainPageTextData>();
                    if (presetData.TextId.HasValue)
                    {
                        textSelectViewModel.SelectedTextId = presetData.TextId.Value;
                    }
                    else
                    {
                        textSelectViewModel.SelectedTextId = 0;
                        textDatas.Add(await _mainPageService.GetDefaultMainPageTextData());
                    }

                    var textModels = textDatas.Select(t => t.TextDataToModel())
                        .ToList();
                    textSelectViewModel.CurrentPresetId = presetId;
                    textSelectViewModel.Texts = textModels;

                    return textSelectViewModel;
                }
            }

            var defaultMainPageTextData = await _mainPageService.GetDefaultMainPageTextData();
            var defaultMainPageTextModel = defaultMainPageTextData.TextDataToModel();

            textSelectViewModel.SelectedTextId = 0;
            textSelectViewModel.CurrentPresetId = 0;
            textSelectViewModel.Texts = new List<MainPageTextModel> { defaultMainPageTextModel };

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

        private async Task<ActionBlockViewModel> GetActionBlockViewModelAsync(int presetId)
        {
            var actionSelectViewModel = new ActionBlockViewModel();

            if (presetId > 0)
            {
                var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
                if (presetData != null)
                {
                    var actionDatas = await _mainPageService.GetAllElementDatasAsync<MainPageActionData>();
                    if (presetData.ActionId.HasValue)
                    {
                        actionSelectViewModel.SelectedActionId = presetData.ActionId.Value;
                    }
                    else
                    {
                        actionSelectViewModel.SelectedActionId = 0;
                        actionDatas.Add(await _mainPageService.GetDefaultMainPageActionData());
                    }

                    var actionModels = actionDatas.Select(a => a.ActionDataToModel())
                        .ToList();
                    actionSelectViewModel.CurrentPresetId = presetId;
                    actionSelectViewModel.Actions = actionModels;

                    return actionSelectViewModel;
                }
            }

            var defaultMainPageActionData = await _mainPageService.GetDefaultMainPageActionData();
            var defaultMainPageActionModel = defaultMainPageActionData.ActionDataToModel();

            actionSelectViewModel.SelectedActionId = 0;
            actionSelectViewModel.CurrentPresetId = 0;
            actionSelectViewModel.Actions = new List<MainPageActionModel> { defaultMainPageActionModel };

            return actionSelectViewModel;
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}