using DataModels;
using Entities;

namespace EntitiesDataModelsConverters
{
    public static class MainPageElementsEntityAndDataModelConverter
    {
        public static MainPagePresetData MainPagePresetEntityToData(this MainPagePresetEntity entity)
        {
            return new MainPagePresetData
            {
                Id = entity.Id,
                PresetName = entity.PresetName,
                IsPublished = entity.IsPublishedOnMainPage,

                ActionId = entity.ActionId,
                ButtonId = entity.ButtonId,
                ImageId = entity.ImageId,
                PhraseId = entity.PhraseId,
                TextId = entity.TextId
            };
        }

        public static MainPagePresetEntity MainPagePresetDataToEntity(this MainPagePresetData data)
        {
            return new MainPagePresetEntity
            {
                Id = data.Id,
                PresetName = data.PresetName,
                IsPublishedOnMainPage = data.IsPublished,

                ActionId = data.ActionId,
                ButtonId = data.ButtonId,
                ImageId = data.ImageId,
                PhraseId = data.PhraseId,
                TextId = data.TextId
            };
        }

        public static MainPageActionData ActionEntityToData(this MainPageActionEntity entity)
        {
            return new MainPageActionData
            {
                Id = entity.Id,
                Action = entity.Action,
            };
        }

        public static MainPageActionEntity ActionDataToEntity(this MainPageActionData data)
        {
            return new MainPageActionEntity
            {
                Id = data.Id,
                Action = data.Action,
            };
        }

        public static MainPageButtonData ButtonEntityToData(this MainPageButtonEntity entity)
        {
            return new MainPageButtonData
            {
                Id = entity.Id,
                Button = entity.Button,
            };
        }

        public static MainPageButtonEntity ButtonDataToEntity(this MainPageButtonData data)
        {
            return new MainPageButtonEntity
            {
                Id = data.Id,
                Button = data.Button,
            };
        }

        public static MainPageImageData ImageEntityToData(this MainPageImageEntity entity)
        {
            return new MainPageImageData
            {
                Id = entity.Id,
                Image = Convert.ToBase64String(entity.ImageAsArray64)
            };
        }

        public static MainPageImageEntity ImageDataToEntity(this MainPageImageData data)
        {
            return new MainPageImageEntity
            {
                Id = data.Id,
                ImageAsArray64 = Convert.FromBase64String(data.Image),
            };
        }

        public static MainPagePhraseData PhraseEntityToData(this MainPagePhraseEntity entity)
        {
            return new MainPagePhraseData
            {
                Id = entity.Id,
                Phrase = entity.Phrase,
            };
        }

        public static MainPagePhraseEntity PhraseDataToEntity(this MainPagePhraseData data)
        {
            return new MainPagePhraseEntity
            {
                Id = data.Id,
                Phrase = data.Phrase,
            };
        }

        public static MainPageTextData TextEntityToData(this MainPageTextEntity entity)
        {
            return new MainPageTextData
            {
                Id = entity.Id,
                Text = entity.Text,
            };
        }

        public static MainPageTextEntity TextDataToEntity(this MainPageTextData data)
        {
            return new MainPageTextEntity
            {
                Id = data.Id,
                Text = data.Text,
            };
        }
    }
}
