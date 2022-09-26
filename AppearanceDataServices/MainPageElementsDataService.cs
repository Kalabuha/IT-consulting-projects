using RepositoryInterfaces;
using ServiceInterfaces;
using DefaultDataServices;
using DataModels.Base;
using DataModels;

namespace AppearanceDataServices
{
    internal class MainPageElementsDataService : DefaultDataService, IMainPageService
    {
        private readonly IRepository<MainPagePresetDataModel> _presetRepository;

        private readonly IRepository<MainPageActionDataModel> _actionRepository;
        private readonly IRepository<MainPageButtonDataModel> _buttonRepository;
        private readonly IRepository<MainPageImageDataModel> _imageRepository;
        private readonly IRepository<MainPagePhraseDataModel> _phraseRepository;
        private readonly IRepository<MainPageTextDataModel> _textRepository;

        public MainPageElementsDataService(
            IRepository<MainPagePresetDataModel> presetRepository,
            IRepository<MainPageActionDataModel> actionRepository,
            IRepository<MainPageButtonDataModel> buttonRepository,
            IRepository<MainPageImageDataModel> imageRepository,
            IRepository<MainPagePhraseDataModel> phraseRepository,
            IRepository<MainPageTextDataModel> textRepository)
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
            var presets = (await _presetRepository.GetAllDataModelsAsync())
                .ToList();

            return presets;
        }

        public async Task<MainPagePresetDataModel?> GetPublishedPresetDataAsync()
        {
            var publishedPreset = (await _presetRepository.GetAllDataModelsAsync())
                .FirstOrDefault(p => p.IsPublished);

            return publishedPreset;
        }

        public async Task<MainPagePresetDataModel?> GetPresetDataByIdAsync(int id)
        {
            var preset = await _presetRepository.GetDataModelAsync(id);

            return preset;
        }

        public async Task PublishPresetAsync(int id)
        {
            var presets = await _presetRepository.GetAllDataModelsAsync();
            if (!presets.Any(p => p.Id == id))
            {
                return;
            }

            foreach (var preset in presets)
            {
                if (preset.Id == id)
                {
                    preset.IsPublished = true;
                }
                else
                {
                    if (preset.IsPublished)
                    {
                        preset.IsPublished = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                await _presetRepository.UpdateDataModelAsync(preset);
            }
        }

        public async Task<int> AddMainPagePresetToDbAsync(MainPagePresetDataModel? data)
        {
            if (data != null)
            {
                var newPreset = await _presetRepository.AddDataModelAsync(data);
                return newPreset.Id;
            }

            return 0;
        }

        public async Task EditMainPagePresetToDbAsync(MainPagePresetDataModel? data)
        {
            if (data != null)
            {
                await _presetRepository.UpdateDataModelAsync(data);
            }
        }

        public async Task RemoveMainPagePresetToDbAsync(MainPagePresetDataModel? data)
        {
            if (data != null)
            {
                await _presetRepository.DeleteDataModelAsync(data.Id);
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
                element = await _actionRepository.GetDataModelAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                element = await _buttonRepository.GetDataModelAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                element = await _imageRepository.GetDataModelAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                element = await _phraseRepository.GetDataModelAsync(id.Value);
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                element = await _textRepository.GetDataModelAsync(id.Value);
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

            var preset = await _presetRepository.GetDataModelAsync(id.Value);
            if (preset == null)
            {
                return null;
            }

            BaseDataModel? element;
            if (typeof(TMainPageData) == typeof(MainPageActionDataModel))
            {
                element = preset.ActionId.HasValue ? await _actionRepository.GetDataModelAsync(preset.ActionId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                element = preset.ButtonId.HasValue ? await _buttonRepository.GetDataModelAsync(preset.ButtonId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                element = preset.ImageId.HasValue ? await _imageRepository.GetDataModelAsync(preset.ImageId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                element = preset.PhraseId.HasValue ? await _phraseRepository.GetDataModelAsync(preset.PhraseId.Value) : null;
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                element = preset.TextId.HasValue ? await _textRepository.GetDataModelAsync(preset.TextId.Value) : null;
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
                elements = await _actionRepository.GetAllDataModelsAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                elements = await _buttonRepository.GetAllDataModelsAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                elements = await _imageRepository.GetAllDataModelsAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                elements = await _phraseRepository.GetAllDataModelsAsync();
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                elements = await _textRepository.GetAllDataModelsAsync();
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
                await _actionRepository.AddDataModelAsync(action);
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                var button = (MainPageButtonDataModel)element;
                await _buttonRepository.AddDataModelAsync(button);
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                var image = (MainPageImageDataModel)element;
                await _imageRepository.AddDataModelAsync(image);
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                var phrase = (MainPagePhraseDataModel)element;
                await _phraseRepository.AddDataModelAsync(phrase);
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                var textData = (MainPageTextDataModel)element;
                await _textRepository.AddDataModelAsync(textData);
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
                await _actionRepository.DeleteDataModelAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonDataModel))
            {
                await _buttonRepository.DeleteDataModelAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageDataModel))
            {
                await _imageRepository.DeleteDataModelAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseDataModel))
            {
                await _phraseRepository.DeleteDataModelAsync(id);
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextDataModel))
            {
                await _textRepository.DeleteDataModelAsync(id);
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }
        }

        public async Task<MainPageTextDataModel> GetDefaultMainPageTextData(string startPathToDefaultData)
        {
            var defaultMainPageTextData = new MainPageTextDataModel
            {
                Id = 0,
                Text = await GetDefaultTextFromFileAsync(startPathToDefaultData, "text.txt")
            };

            return defaultMainPageTextData;
        }

        public async Task<MainPageActionDataModel> GetDefaultMainPageActionData(string startPathToDefaultData)
        {
            var defaultMainPageActionData = new MainPageActionDataModel
            {
                Id = 0,
                Action = await GetDefaultTextFromFileAsync(startPathToDefaultData, "action.txt")
            };

            return defaultMainPageActionData;
        }
    }
}
