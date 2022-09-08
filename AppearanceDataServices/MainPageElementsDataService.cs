using RepositoryInterfaces;
using ServiceInterfaces;
using DefaultDataServices;
using DataModels.Base;
using DataModels;

namespace AppearanceDataServices
{
    internal class MainPageElementsDataService : DefaultDataService, IMainPageService
    {
        private readonly IMainPagePresetRepository _presetRepository;

        private readonly IMainPageActionRepository _actionRepository;
        private readonly IMainPageButtonRepository _buttonRepository;
        private readonly IMainPageImageRepository _imageRepository;
        private readonly IMainPagePhraseRepository _phraseRepository;
        private readonly IMainPageTextRepository _textRepository;

        public MainPageElementsDataService(
            IMainPagePresetRepository presetRepository,
            IMainPageActionRepository actionRepository,
            IMainPageButtonRepository buttonRepository,
            IMainPageImageRepository imageRepository,
            IMainPagePhraseRepository phraseRepository,
            IMainPageTextRepository textRepository)
        {
            _presetRepository = presetRepository;

            _actionRepository = actionRepository;
            _buttonRepository = buttonRepository;
            _imageRepository = imageRepository;
            _phraseRepository = phraseRepository;
            _textRepository = textRepository;
        }

        public async Task<List<MainPagePresetDataModel>> GetAllPresetDatasAsync()
        {
            var presets = (await _presetRepository.GetAllMainPagePresetsAsync())
                .ToList();

            return presets;
        }

        public async Task<MainPagePresetDataModel?> GetPublishedPresetDataAsync()
        {
            var publishedPreset = (await _presetRepository.GetAllMainPagePresetsAsync())
                .FirstOrDefault(p => p.IsPublished);

            return publishedPreset;
        }

        public async Task<MainPagePresetDataModel?> GetPresetDataByIdAsync(int id)
        {
            var preset = await _presetRepository.GetMainPagePresetAsync(id);

            return preset;
        }

        public async Task PublishPresetAsync(int id)
        {
            var preset = await _presetRepository.GetMainPagePresetAsync(id);
            if (preset == null)
            {
                return;
            }

            var publishPresets = (await _presetRepository.GetAllMainPagePresetsAsync())
                .Where(p => p.IsPublished)
                .ToArray();

            foreach (var publishPreset in publishPresets)
            {
                publishPreset.IsPublished = false;
                await _presetRepository.UpdateMainPagePresetAsync(publishPreset);
            }

            preset.IsPublished = true;
            await _presetRepository.UpdateMainPagePresetAsync(preset);
        }

        public async Task<int> AddMainPagePresetToDbAsync(MainPagePresetDataModel? data)
        {
            if (data != null)
            {
                var id = await _presetRepository.AddMainPagePresetAsync(data);

                return id;
            }

            return 0;
        }

        public async Task EditMainPagePresetToDbAsync(MainPagePresetDataModel? data)
        {
            if (data != null)
            {
                await _presetRepository.UpdateMainPagePresetAsync(data);
            }
        }

        public async Task RemoveMainPagePresetToDbAsync(MainPagePresetDataModel? data)
        {
            if (data != null)
            {
                await _presetRepository.DeleteMainPagePresetAsync(data.Id);
            }
        }

        public async Task<TMainPageData?> GetElementDataByIdAsync<TMainPageData>(int? id) where TMainPageData : BaseDataModel
        {
            if (!id.HasValue)
            {
                return null;
            }

            BaseDataModel? element;
            if (typeof(TMainPageData) == typeof(MainPageActionDataModel))
            {
                element = await _actionRepository.GetMainPageActionAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                element = await _buttonRepository.GetMainPageButtonAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                element = await _imageRepository.GetMainPageImageAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                element = await _phraseRepository.GetMainPagePhraseAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                element = await _textRepository.GetMainPageTextAsync(id.Value);
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }

            return (TMainPageData?)element;
        }

        public async Task<TMainPageData?> GetElementDataByPresetIdAsync<TMainPageData>(int? id) where TMainPageData : BaseDataModel
        {
            if (!id.HasValue)
            {
                return null;
            }

            var preset = await _presetRepository.GetMainPagePresetAsync(id.Value);
            if (preset == null)
            {
                return null;
            }

            BaseDataModel? element;
            if (typeof(TMainPageData) == typeof(MainPageActionDataModel))
            {
                element = preset.ActionId.HasValue ? await _actionRepository.GetMainPageActionAsync(preset.ActionId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                element = preset.ButtonId.HasValue ? await _buttonRepository.GetMainPageButtonAsync(preset.ButtonId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                element = preset.ImageId.HasValue ? await _imageRepository.GetMainPageImageAsync(preset.ImageId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                element = preset.PhraseId.HasValue ? await _phraseRepository.GetMainPagePhraseAsync(preset.PhraseId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                element = preset.TextId.HasValue ? await _textRepository.GetMainPageTextAsync(preset.TextId.Value) : null;
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }

            return (TMainPageData?)element;
        }

        public async Task<List<TMainPageData>> GetAllElementDatasAsync<TMainPageData>() where TMainPageData : BaseDataModel
        {
            IEnumerable<BaseDataModel> elements;
            if (typeof(TMainPageData) == typeof(MainPageActionDataModel))
            {
                elements = await _actionRepository.GetAllMainPageActionsAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                elements = await _buttonRepository.GetAllMainPageButtonsAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                elements = await _imageRepository.GetAllMainPageImagesAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                elements = await _phraseRepository.GetAllMainPagePhrasesAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                elements = await _textRepository.GetAllMainPageTextsAsync();
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }

            return elements.Select(e => (TMainPageData)e).ToList();
        }

        public async Task AddElementToDbAsync<TMainPageData>(TMainPageData data) where TMainPageData : BaseDataModel
        {
            BaseDataModel element = data;
            if (typeof(TMainPageData) == typeof(MainPageActionDataModel))
            {
                var action = (MainPageActionDataModel)element;
                await _actionRepository.AddMainPageActionAsync(action);
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                var button = (MainPageButtonDataModel)element;
                await _buttonRepository.AddMainPageButtonAsync(button);
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                var image = (MainPageImageDataModel)element;
                await _imageRepository.AddMainPageImageAsync(image);
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                var phrase = (MainPagePhraseDataModel)element;
                await _phraseRepository.AddMainPagePhraseAsync(phrase);
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                var textData = (MainPageTextDataModel)element;
                await _textRepository.AddMainPageTextAsync(textData);
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }
        }

        public async Task DeleteElementToDbAsync<TMainPageData>(int id) where TMainPageData : BaseDataModel
        {
            if (typeof(TMainPageData) == typeof(MainPageActionDataModel))
            {
                await _actionRepository.DeleteMainPageActionAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                await _buttonRepository.DeleteMainPageButtonAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                await _imageRepository.DeleteMainPageImageAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                await _phraseRepository.DeleteMainPagePhraseAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                await _textRepository.DeleteMainPageTextAsync(id);
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }
        }

        public async Task<MainPageTextDataModel> GetDefaultMainPageTextData()
        {
            var defaultMainPageTextData = new MainPageTextDataModel
            {
                Id = 0,
                Text = await GetDefaultTextFromFileAsync("text.txt")
            };

            return defaultMainPageTextData;
        }

        public async Task<MainPageActionDataModel> GetDefaultMainPageActionData()
        {
            var defaultMainPageActionData = new MainPageActionDataModel
            {
                Id = 0,
                Action = await GetDefaultTextFromFileAsync("action.txt")
            };

            return defaultMainPageActionData;
        }
    }
}
