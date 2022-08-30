using DataModels;
using WebModels;

namespace DataModelsWebModelsConverters
{
    public static class MenuDataModelAndWebModelConverter
    {
        public static MenuModel MenuDataToModel(this MenuData data)
        {
            return new MenuModel
            {
                Id = data.Id,
                Main = data.Main,
                Services = data.Services,
                Projects = data.Projects,
                Blogs = data.Blogs,
                Contacts = data.Contacts,
                IsPublished = data.IsPublished
            };
        }

        public static MenuData MenuModelToData(this MenuModel model)
        {
            return new MenuData
            {
                Id = model.Id,
                Main = model.Main,
                Services = model.Services,
                Projects = model.Projects,
                Blogs = model.Blogs,
                Contacts = model.Contacts,
                IsPublished = model.IsPublished
            };
        }
    }
}
