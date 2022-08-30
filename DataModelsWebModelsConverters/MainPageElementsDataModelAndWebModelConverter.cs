using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsConverters
{
    public static class MainPageElementsDataModelAndWebModelConverter
    {
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

        public static MainPageImageModel ImageDataToModel(this MainPageImageData data)
        {
            return new MainPageImageModel
            {
                Id = data.Id,
                ImageAsString = string.Format("data:image/jpg;base64,{0}", data.Image)
            };
        }

        public static MainPageImageData ImageModelToData(this MainPageImageModel model)
        {
            var data = new MainPageImageData
            {
                Id = model.Id
            };

            if (model.ImageAsFormFile != null)
            {
                data.Image = ImageWebDataConverter.ReadBytesFromFormFile(model.ImageAsFormFile);
            }

            return data;
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
