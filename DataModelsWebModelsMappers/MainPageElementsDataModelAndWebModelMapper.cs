using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsMappers
{
    public static class MainPageElementsDataModelAndWebModelMapper
    {
        public static MainPagePresetWebModel MainPagePresetDataToModel(this MainPagePresetDataModel data)
        {
            return new MainPagePresetWebModel
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

        public static MainPagePresetDataModel MainPagePresetModelToData(this MainPagePresetWebModel model)
        {
            return new MainPagePresetDataModel
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

        public static MainPageActionWebModel ActionDataToModel(this MainPageActionDataModel data)
        {
            return new MainPageActionWebModel
            {
                Id = data.Id,
                Action = data.Action,
            };
        }

        public static MainPageActionDataModel ActionModelToData(this MainPageActionWebModel model)
        {
            return new MainPageActionDataModel
            {
                Id = model.Id,
                Action = model.Action,
            };
        }

        public static MainPageButtonWebModel ButtonDataToModel(this MainPageButtonDataModel data)
        {
            return new MainPageButtonWebModel
            {
                Id = data.Id,
                Button = data.Button,
            };
        }

        public static MainPageButtonDataModel ButtonModelToData(this MainPageButtonWebModel model)
        {
            return new MainPageButtonDataModel
            {
                Id = model.Id,
                Button = model.Button,
            };
        }

        public static MainPageImageWebModel ImageDataToModel(this MainPageImageDataModel data)
        {
            var imageAsString = Convert.ToBase64String(data.ImageAsByte);

            return new MainPageImageWebModel
            {
                Id = data.Id,
                ImageAsString = string.Format("data:image/jpg;base64,{0}", imageAsString)
            };
        }

        public static MainPageImageDataModel ImageModelToData(this MainPageImageWebModel model)
        {
            var data = new MainPageImageDataModel
            {
                Id = model.Id
            };

            if (model.ImageAsFormFile != null)
            {
                var imageAsString = ImageWebDataConverter.ConvertImageFromFormFileToBytes(model.ImageAsFormFile);
                data.ImageAsByte = Convert.FromBase64String(imageAsString);
            }

            return data;
        }

        public static MainPagePhraseWebModel PhraseDataToModel(this MainPagePhraseDataModel data)
        {
            return new MainPagePhraseWebModel
            {
                Id = data.Id,
                Phrase = data.Phrase,
            };
        }

        public static MainPagePhraseDataModel PhraseModelToData(this MainPagePhraseWebModel model)
        {
            return new MainPagePhraseDataModel
            {
                Id = model.Id,
                Phrase = model.Phrase,
            };
        }

        public static MainPageTextWebModel TextDataToModel(this MainPageTextDataModel data)
        {
            return new MainPageTextWebModel
            {
                Id = data.Id,
                Text = data.Text,
            };
        }

        public static MainPageTextDataModel TextModelToData(this MainPageTextWebModel model)
        {
            return new MainPageTextDataModel
            {
                Id = model.Id,
                Text = model.Text,
            };
        }
    }
}
