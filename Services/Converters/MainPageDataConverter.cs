using Resources.Entities;
using Resources.Models;
using Resources.Datas;

namespace Services.Converters
{
    public static class MainPageDataConverter
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

        public static MainPagePresetModel MainPagePresetDataToModel(this MainPagePresetData data)
        {
            return new MainPagePresetModel
            {
                Id = data.Id,
                PresetName = data.PresetName,
                IsPublished = data.IsPublished,

                ActionId = data.ActionId,
                ButtonId = data.ButtonId,
                ImageId = data.ImageId,
                PhraseId = data.PhraseId,
                TextId = data.TextId
            };
        }

        public static MainPagePresetData MainPagePresetModelToData(this MainPagePresetModel model)
        {
            return new MainPagePresetData
            {
                Id = model.Id,
                PresetName = model.PresetName,
                IsPublished = model.IsPublished,

                ActionId = model.ActionId,
                ButtonId = model.ButtonId,
                ImageId = model.ImageId,
                PhraseId = model.PhraseId,
                TextId = model.TextId
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

         public static MainPageActionModel ActionDataToModel(this MainPageActionData data)
        {
            return new MainPageActionModel
            {
                Id = data.Id,
                Action = data.Action,
            };
        }

        public static MainPageActionData ActionModelToData(this MainPageActionModel model)
        {
            return new MainPageActionData
            {
                Id = model.Id,
                Action = model.Action,
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

        public static MainPageButtonModel ButtonDataToModel(this MainPageButtonData data)
        {
            return new MainPageButtonModel
            {
                Id = data.Id,
                Button = data.Button,
            };
        }

        public static MainPageButtonData ButtonModelToData(this MainPageButtonModel model)
        {
            return new MainPageButtonData
            {
                Id = model.Id,
                Button = model.Button,
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

        public static MainPageImageModel ImageDataToModel(this MainPageImageData data)
        {
            return new MainPageImageModel
            {
                Id = data.Id,
                Image = string.Format("data:image/jpg;base64,{0}", data.Image)
            };
        }

        public static MainPageImageData ImageModelToData(this MainPageImageModel model)
        {
            return new MainPageImageData
            {
                Id = model.Id,
                Image = model.Image,
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

        public static MainPagePhraseModel PhraseDataToModel(this MainPagePhraseData data)
        {
            return new MainPagePhraseModel
            {
                Id = data.Id,
                Phrase = data.Phrase,
            };
        }

        public static MainPagePhraseData PhraseModelToData(this MainPagePhraseModel model)
        {
            return new MainPagePhraseData
            {
                Id = model.Id,
                Phrase = model.Phrase,
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

        public static MainPageTextModel TextDataToModel(this MainPageTextData data)
        {
            return new MainPageTextModel
            {
                Id = data.Id,
                Text = data.Text,
            };
        }

        public static MainPageTextData TextModelToData(this MainPageTextModel model)
        {
            return new MainPageTextData
            {
                Id = model.Id,
                Text = model.Text,
            };
        }
    }
}
