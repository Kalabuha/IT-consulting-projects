using DataModels;
using WebModels;

namespace DataModelsWebModelsMappers
{
    public static class MenuDataModelAndWebModelMapper
    {
        public static HeaderMenuWebModel MenuDataToModel(this HeaderMenuDataModel data)
        {
            return new HeaderMenuWebModel
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

        public static HeaderMenuDataModel MenuModelToData(this HeaderMenuWebModel model)
        {
            return new HeaderMenuDataModel
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
