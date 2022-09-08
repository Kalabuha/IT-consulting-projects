using DataModels;
using Entities;

namespace EntitiesDataModelsMappers
{
    public static class MainPageElementsEntityAndDataModelMapper
    {
        public static MainPagePresetDataModel MainPagePresetEntityToData(this MainPagePresetEntity entity)
        {
            return new MainPagePresetDataModel
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

        public static MainPagePresetEntity MainPagePresetDataToEntity(this MainPagePresetDataModel data, MainPagePresetEntity? entity = null)
        {
            entity ??= new MainPagePresetEntity();

            entity.Id = data.Id;
            entity.PresetName = data.PresetName;
            entity.IsPublishedOnMainPage = data.IsPublished;

            entity.ActionId = data.ActionId;
            entity.ButtonId = data.ButtonId;
            entity.ImageId = data.ImageId;
            entity.PhraseId = data.PhraseId;
            entity.TextId = data.TextId;

            return entity;
        }

        public static MainPageActionDataModel MainPageActionEntityToData(this MainPageActionEntity entity)
        {
            return new MainPageActionDataModel
            {
                Id = entity.Id,
                Action = entity.Action,
            };
        }

        public static MainPageActionEntity MainPageActionDataToEntity(this MainPageActionDataModel data, MainPageActionEntity? entity = null)
        {
            entity ??= new MainPageActionEntity();

            entity.Id = data.Id;
            entity.Action = data.Action;

            return entity;
        }

        public static MainPageButtonDataModel MainPageButtonEntityToData(this MainPageButtonEntity entity)
        {
            return new MainPageButtonDataModel
            {
                Id = entity.Id,
                Button = entity.Button,
            };
        }

        public static MainPageButtonEntity MainPageButtonDataToEntity(this MainPageButtonDataModel data, MainPageButtonEntity? entity = null)
        {
            entity ??= new MainPageButtonEntity();

            entity.Id = data.Id;
            entity.Button = data.Button;

            return entity;
        }

        public static MainPageImageDataModel MainPageImageEntityToData(this MainPageImageEntity entity)
        {
            return new MainPageImageDataModel
            {
                Id = entity.Id,
                ImageAsByte = entity.ImageAsArray64
            };
        }

        public static MainPageImageEntity MainPageImageDataToEntity(this MainPageImageDataModel data, MainPageImageEntity? entity = null)
        {
            entity ??= new MainPageImageEntity();

            entity.Id = data.Id;
            entity.ImageAsArray64 = data.ImageAsByte;

            return entity;
        }

        public static MainPagePhraseDataModel MainPagePhraseEntityToData(this MainPagePhraseEntity entity)
        {
            return new MainPagePhraseDataModel
            {
                Id = entity.Id,
                Phrase = entity.Phrase,
            };
        }

        public static MainPagePhraseEntity MainPagePhraseDataToEntity(this MainPagePhraseDataModel data, MainPagePhraseEntity? entity = null)
        {
            entity ??= new MainPagePhraseEntity();

            entity.Id = data.Id;
            entity.Phrase = data.Phrase;

            return entity;
        }

        public static MainPageTextDataModel MainPageTextEntityToData(this MainPageTextEntity entity)
        {
            return new MainPageTextDataModel
            {
                Id = entity.Id,
                Text = entity.Text,
            };
        }

        public static MainPageTextEntity MainPageTextDataToEntity(this MainPageTextDataModel data, MainPageTextEntity? entity = null)
        {
            entity ??= new MainPageTextEntity();

            entity.Id = data.Id;
            entity.Text = data.Text;

            return entity;
        }
    }
}
