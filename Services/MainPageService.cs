using Repositories.Interfaces;
using Resources.Datas;
using Resources.Datas.Base;
using Resources.Entities;
using Services.Common;
using Services.Converters;
using Services.Interfaces;

namespace Services
{
    internal class MainPageService : DefaultDataService, IMainPageService
    {
        private readonly IMainPagePresetRepository _presetRepository;

        private readonly IMainPageActionRepository _actionRepository;
        private readonly IMainPageButtonRepository _buttonRepository;
        private readonly IMainPageImageRepository _imageRepository;
        private readonly IMainPagePhraseRepository _phraseRepository;
        private readonly IMainPageTextRepository _textRepository;

        public MainPageService(
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

        public async Task<List<MainPagePresetData>> GetAllPresetDatasAsync()
        {
            var presetEntities = await _presetRepository.GetAllMainPagePresetEntitiesAsync();

            var presetDatas = presetEntities
                .Select(p => p.MainPagePresetEntityToData())
                .ToList();

            return presetDatas;
        }

        public async Task<MainPagePresetData?> GetPublishedPresetDataAsync()
        {
            var publishedPresetEntity = await _presetRepository.GetPublishedMainPagePresetEntityAsync();

            var publishedPresetData = publishedPresetEntity?.MainPagePresetEntityToData();

            return publishedPresetData;
        }

        public async Task<MainPagePresetData?> GetPresetDataByIdAsync(int id)
        {
            var presetEntity = await _presetRepository.GetEntity(id);

            var presetData = presetEntity?.MainPagePresetEntityToData();

            return presetData;
        }

        public async Task PublishPreset(int id)
        {
            var entity = await _presetRepository.GetEntity(id);
            if (entity == null)
            {
                return;
            }

            var publishEntities = await _presetRepository.GetAllPublishedPresetEntityAsync();
            foreach (var publishEntity in publishEntities)
            {
                publishEntity.IsPublishedOnMainPage = false;
                await _presetRepository.UpdateEntityAsync(publishEntity);
            }

            entity.IsPublishedOnMainPage = true;
            await _presetRepository.UpdateEntityAsync(entity);
        }

        public async Task<int> CreatePreset(MainPagePresetData data)
        {
            var entity = new MainPagePresetEntity()
            {
                PresetName = data.PresetName,
            };

            await _presetRepository.AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task UpdatePreset(MainPagePresetData data)
        {
            var entity = await _presetRepository.GetEntity(data.Id);
            if (entity == null)
            {
                return;
            }

            entity.PresetName = data.PresetName;
            entity.IsPublishedOnMainPage = data.IsPublished;
            entity.ActionId = data.ActionId;
            entity.ButtonId = data.ButtonId;
            entity.ImageId = data.ImageId;
            entity.PhraseId = data.PhraseId;
            entity.TextId = data.TextId;

            await _presetRepository.UpdateEntityAsync(entity);
        }

        public async Task DeletePreset(MainPagePresetData data)
        {
            var entity = await _presetRepository.GetEntity(data.Id);
            if (entity == null)
            {
                return;
            }

            await _presetRepository.RemoveEntityAsync(entity);
        }

        public async Task<TMainPageData?> GetElementDataByIdAsync<TMainPageData>(int? id) where TMainPageData : BaseData
        {
            if (!id.HasValue)
            {
                return null;
            }

            BaseData? elementData;
            if (typeof(TMainPageData) == typeof(MainPageActionData))
            {
                var actionEntity = await _actionRepository.GetEntity(id);
                elementData = actionEntity?.ActionEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonData))
            {
                var buttonEntity = await _buttonRepository.GetEntity(id);
                elementData = buttonEntity?.ButtonEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageData))
            {
                var imageEntity = await _imageRepository.GetEntity(id);
                elementData = imageEntity?.ImageEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseData))
            {
                var phraseEntity = await _phraseRepository.GetEntity(id);
                elementData = phraseEntity?.PhraseEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextData))
            {
                var textEntity = await _textRepository.GetEntity(id);
                elementData = textEntity?.TextEntityToData();
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }

            return (TMainPageData?)elementData;
        }

        public async Task<TMainPageData?> GetElementDataByPresetIdAsync<TMainPageData>(int? id) where TMainPageData : BaseData
        {
            var preset = await _presetRepository.GetEntity(id);
            if (preset == null)
            {
                return null;
            }

            BaseData? elementData;
            if (typeof(TMainPageData) == typeof(MainPageActionData))
            {
                var actionEntity = await _actionRepository.GetEntity(preset.ActionId);
                elementData = actionEntity?.ActionEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonData))
            {
                var buttonEntity = await _buttonRepository.GetEntity(preset.ButtonId);
                elementData = buttonEntity?.ButtonEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageData))
            {
                var imageEntity = await _imageRepository.GetEntity(preset.ImageId);
                elementData = imageEntity?.ImageEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseData))
            {
                var phraseEntity = await _phraseRepository.GetEntity(preset.PhraseId);
                elementData = phraseEntity?.PhraseEntityToData();
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextData))
            {
                var textEntity = await _textRepository.GetEntity(preset.TextId);
                elementData = textEntity?.TextEntityToData();
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }

            return (TMainPageData?)elementData;
        }

        public async Task<List<TMainPageData>> GetAllElementDatasAsync<TMainPageData>() where TMainPageData : BaseData
        {
            IEnumerable<BaseData> elementDatas;
            if (typeof(TMainPageData) == typeof(MainPageActionData))
            {
                var actionEntities = await _actionRepository.GetAllMainPageActionEntitiesAsync();
                elementDatas = actionEntities.Select(a => a.ActionEntityToData());
            }
            else if (typeof(TMainPageData) == typeof(MainPageButtonData))
            {
                var buttonEntities = await _buttonRepository.GetAllMainPageButtonEntitiesAsync();
                elementDatas = buttonEntities.Select(b => b.ButtonEntityToData());
            }
            else if (typeof(TMainPageData) == typeof(MainPageImageData))
            {
                var imageEntities = await _imageRepository.GetAllMainPageImageEntitiesAsync();
                elementDatas = imageEntities.Select(i => i.ImageEntityToData());
            }
            else if (typeof(TMainPageData) == typeof(MainPagePhraseData))
            {
                var phraseEntities = await _phraseRepository.GetAllMainPagePhraseEntitiesAsync();
                elementDatas = phraseEntities.Select(p => p.PhraseEntityToData());
            }
            else if (typeof(TMainPageData) == typeof(MainPageTextData))
            {
                var phraseEntities = await _textRepository.GetAllMainPageTextEntitiesAsync();
                elementDatas = phraseEntities.Select(p => p.TextEntityToData());
            }
            else
            {
                throw new ApplicationException("Неизвестная модель");
            }

            return elementDatas.Select(e => (TMainPageData)e).ToList();
        }

        public async Task<MainPageTextData> GetDefaultMainPageTextData()
        {
            var defaultMainPageTextData = new MainPageTextData
            {
                Id = 0,
                Text = await GetDefaultTextFromFileAsync("text.txt")
            };

            return defaultMainPageTextData;
        }

        public async Task<MainPageActionData> GetDefaultMainPageActionData()
        {
            var defaultMainPageActionData = new MainPageActionData
            {
                Id = 0,
                Action = await GetDefaultTextFromFileAsync("action.txt")
            };

            return defaultMainPageActionData;
        }
    }
}
