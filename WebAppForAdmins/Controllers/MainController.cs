using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using WebAppForAdmins.Models.Main;
using WebAppForAdmins.Models;
using ServiceInterfaces;
using DataModelsWebModelsMappers;
using WebModels;
using DataModels;

namespace WebAppForAdmins.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMainPageService _mainPageService;

        private readonly string _startPathToDefaultData;

        public MainController(ILogger<MainController> logger, IMainPageService mainPageService)
        {
            _startPathToDefaultData = @"..\DefaultDataServices\DefaultData\txt";
            _logger = logger;
            _mainPageService = mainPageService;
        }

        #region Пресеты
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var presetDatas = await _mainPageService.GetAllPresetDatasAsync();
            var presetModels = presetDatas.Select(p => p.MainPagePresetDataToModel())
                .ToList();

            MainPagePresetDataModel? selectedPresetData;
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

                await _mainPageService.RemoveMainPagePresetToDbAsync(data);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePreset(MainPagePresetWebModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index));
            }

            var data = model.MainPagePresetModelToData();
            var id = await _mainPageService.AddMainPagePresetToDbAsync(data);

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
                var textData = await _mainPageService.GetElementDataByIdAsync<MainPageTextDataModel>(model.SelectedTextId);
                if (textData != null)
                {
                    presetData.TextId = textData.Id;
                    await _mainPageService.EditMainPagePresetToDbAsync(presetData);
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
                await _mainPageService.EditMainPagePresetToDbAsync(presetData);
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
                    var textData = new MainPageTextDataModel()
                    {
                        Text = model.TextContent!
                    };

                    await _mainPageService.AddElementToDbAsync(textData);
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
                await _mainPageService.DeleteElementToDbAsync<MainPageTextDataModel>(model.SelectedTextId);
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
        #endregion

        #region Блок изображения - изображение (ImageBlock - _ImageSelect)
        [HttpPost]
        public async Task<IActionResult> SelectImageForCurrentPreset(ImageForCurrentPresetModel model)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(model.CurrentPresetId);
            if (presetData != null)
            {
                var imageData = await _mainPageService.GetElementDataByIdAsync<MainPageImageDataModel>(model.SelectedImageId);
                if (imageData != null)
                {
                    presetData.ImageId = imageData.Id;
                    await _mainPageService.EditMainPagePresetToDbAsync(presetData);
                }
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImageForCurrentPreset(int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);

            if (presetData != null)
            {
                presetData.ImageId = null;
                await _mainPageService.EditMainPagePresetToDbAsync(presetData);
            }

            var viewModel = await GetImageBlockViewModelAsync(presetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(AddedImageModel model)
        {
            if (model != null && model.AddedImageAsFormFile != null)
            {
                var imageModel = new MainPageImageWebModel
                {
                    ImageAsFormFile = model.AddedImageAsFormFile,
                };

                var imageData = imageModel.ImageModelToData();

                await _mainPageService.AddElementToDbAsync(imageData);
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(ImageForCurrentPresetModel model)
        {
            if (model.SelectedImageId > 0)
            {
                await _mainPageService.DeleteElementToDbAsync<MainPageImageDataModel>(model.SelectedImageId);
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }
        #endregion

        #region Блок изображения - кнопка (ImageBlock - _ButtonSelect)
        [HttpPost]
        public async Task<IActionResult> SelectButtonForCurrentPreset(ButtonForCurrentPresetModel model)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(model.CurrentPresetId);
            if (presetData != null)
            {
                var buttonData = await _mainPageService.GetElementDataByIdAsync<MainPageButtonDataModel>(model.SelectedButtonId);
                if (buttonData != null)
                {
                    presetData.ButtonId = buttonData.Id;
                    await _mainPageService.EditMainPagePresetToDbAsync(presetData);
                }
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveButtonForCurrentPreset(int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
            if (presetData != null)
            {
                presetData.ButtonId = null;
                await _mainPageService.EditMainPagePresetToDbAsync(presetData);
            }

            var viewModel = await GetImageBlockViewModelAsync(presetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateButton(CreateButtonModel model)
        {
            if (!(string.IsNullOrEmpty(model.ButtonContent) || string.IsNullOrWhiteSpace(model.ButtonContent)))
            {
                model.ButtonContent = model.ButtonContent.Trim();
                if (model.ButtonContent.Length <= 16)
                {
                    var buttonData = new MainPageButtonDataModel()
                    {
                        Button = model.ButtonContent!
                    };

                    await _mainPageService.AddElementToDbAsync(buttonData);
                }
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteButton(ButtonForCurrentPresetModel model)
        {
            if (model.SelectedButtonId > 0)
            {
                await _mainPageService.DeleteElementToDbAsync<MainPageButtonDataModel>(model.SelectedButtonId);
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }
        #endregion

        #region Блок изображения - фраза (ImageBlock - _PhraseSelect)
        [HttpPost]
        public async Task<IActionResult> SelectPhraseForCurrentPreset(PhraseForCurrentPresetModel model)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(model.CurrentPresetId);
            if (presetData != null)
            {
                var phraseData = await _mainPageService.GetElementDataByIdAsync<MainPagePhraseDataModel>(model.SelectedPhraseId);
                if (phraseData != null)
                {
                    presetData.PhraseId = phraseData.Id;
                    await _mainPageService.EditMainPagePresetToDbAsync(presetData);
                }
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePhraseForCurrentPreset(int presetId)
        {
            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
            if (presetData != null)
            {
                presetData.PhraseId = null;
                await _mainPageService.EditMainPagePresetToDbAsync(presetData);
            }

            var viewModel = await GetImageBlockViewModelAsync(presetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhrase(CreatePhraseModel model)
        {
            if (!(string.IsNullOrEmpty(model.PhraseContent) || string.IsNullOrWhiteSpace(model.PhraseContent)))
            {
                model.PhraseContent = model.PhraseContent.Trim();
                if (model.PhraseContent.Length <= 44)
                {
                    var phraseData = new MainPagePhraseDataModel()
                    {
                        Phrase = model.PhraseContent!
                    };

                    await _mainPageService.AddElementToDbAsync(phraseData);
                }
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePhrase(PhraseForCurrentPresetModel model)
        {
            if (model.SelectedPhraseId > 0)
            {
                await _mainPageService.DeleteElementToDbAsync<MainPagePhraseDataModel>(model.SelectedPhraseId);
            }

            var viewModel = await GetImageBlockViewModelAsync(model.CurrentPresetId);
            return PartialView(nameof(ImageBlock), viewModel);
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
                var actionData = await _mainPageService.GetElementDataByIdAsync<MainPageActionDataModel>(model.SelectedActionId);
                if (actionData != null)
                {
                    presetData.ActionId = actionData.Id;
                    await _mainPageService.EditMainPagePresetToDbAsync(presetData);
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
                await _mainPageService.EditMainPagePresetToDbAsync(presetData);
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
                    var actionData = new MainPageActionDataModel()
                    {
                        Action = model.ActionContent!
                    };

                    await _mainPageService.AddElementToDbAsync(actionData);
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
                await _mainPageService.DeleteElementToDbAsync<MainPageActionDataModel>(model.SelectedActionId);
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
                    var textDatas = await _mainPageService.GetAllElementDatasAsync<MainPageTextDataModel>();
                    if (presetData.TextId.HasValue)
                    {
                        textSelectViewModel.SelectedTextId = presetData.TextId.Value;
                    }
                    else
                    {
                        textSelectViewModel.SelectedTextId = 0;
                        textDatas.Add(await _mainPageService.GetDefaultMainPageTextData(_startPathToDefaultData));
                    }

                    var textModels = textDatas.Select(t => t.TextDataToModel())
                        .ToList();
                    textSelectViewModel.CurrentPresetId = presetId;
                    textSelectViewModel.Texts = textModels;

                    return textSelectViewModel;
                }
            }

            var defaultMainPageTextData = await _mainPageService.GetDefaultMainPageTextData(_startPathToDefaultData);
            var defaultMainPageTextModel = defaultMainPageTextData.TextDataToModel();

            textSelectViewModel.SelectedTextId = 0;
            textSelectViewModel.CurrentPresetId = 0;
            textSelectViewModel.Texts = new List<MainPageTextWebModel> { defaultMainPageTextModel };

            return textSelectViewModel;
        }

        private async Task<ImageBlockViewModel> GetImageBlockViewModelAsync(int presetId)
        {
            ImageBlockViewModel viewModel;

            var presetData = await _mainPageService.GetPresetDataByIdAsync(presetId);
            if (presetData == null)
            {
                viewModel = ImageBlockViewModel.CreateEmptyImageBlockViewModel();
            }
            else
            {
                var allImageDatas = await _mainPageService.GetAllElementDatasAsync<MainPageImageDataModel>();
                var allImageModels = allImageDatas.Select(i => i.ImageDataToModel())
                    .ToList();

                var allButtonDatas = await _mainPageService.GetAllElementDatasAsync<MainPageButtonDataModel>();
                var allButtonModels = allButtonDatas.Select(b => b.ButtonDataToModel())
                    .ToList();

                var allPhraseDatas = await _mainPageService.GetAllElementDatasAsync<MainPagePhraseDataModel>();
                var allPhraseModels = allPhraseDatas.Select(p => p.PhraseDataToModel())
                    .ToList();

                viewModel = new ImageBlockViewModel
                {
                    CurrentPresetId = presetId,
                    SelectedImageId = presetData.ImageId.HasValue ? presetData.ImageId.Value : 0,
                    SelectedButtonId = presetData.ButtonId.HasValue ? presetData.ButtonId.Value : 0,
                    SelectedPhraseId = presetData.PhraseId.HasValue ? presetData.PhraseId.Value : 0,
                    Images = allImageModels,
                    Phrases = allPhraseModels,
                    Buttons = allButtonModels
                };
            }

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
                    var actionDatas = await _mainPageService.GetAllElementDatasAsync<MainPageActionDataModel>();
                    if (presetData.ActionId.HasValue)
                    {
                        actionSelectViewModel.SelectedActionId = presetData.ActionId.Value;
                    }
                    else
                    {
                        actionSelectViewModel.SelectedActionId = 0;
                        actionDatas.Add(await _mainPageService.GetDefaultMainPageActionData(_startPathToDefaultData));
                    }

                    var actionModels = actionDatas.Select(a => a.ActionDataToModel())
                        .ToList();
                    actionSelectViewModel.CurrentPresetId = presetId;
                    actionSelectViewModel.Actions = actionModels;

                    return actionSelectViewModel;
                }
            }

            var defaultMainPageActionData = await _mainPageService.GetDefaultMainPageActionData(_startPathToDefaultData);
            var defaultMainPageActionModel = defaultMainPageActionData.ActionDataToModel();

            actionSelectViewModel.SelectedActionId = 0;
            actionSelectViewModel.CurrentPresetId = 0;
            actionSelectViewModel.Actions = new List<MainPageActionWebModel> { defaultMainPageActionModel };

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