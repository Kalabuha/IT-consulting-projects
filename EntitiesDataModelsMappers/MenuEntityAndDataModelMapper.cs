using Entities;
using DataModels;

namespace EntitiesDataModelsMappers
{
    public static class MenuEntityAndDataModelMapper
    {
        public static HeaderMenuDataModel HeaderMenuEntityToData(HeaderMenuEntity entity)
        {
            return new HeaderMenuDataModel
            {
                Id = entity.Id,
                Main = entity.Main,
                Services = entity.Services,
                Projects = entity.Projects,
                Blogs = entity.Blogs,
                Contacts = entity.Contacts,
                IsPublished = entity.IsPublishedOnMainPage
            };
        }

        public static HeaderMenuEntity HeaderMenuDataToEntity(HeaderMenuDataModel data, HeaderMenuEntity? entity = null)
        {
            entity ??= new HeaderMenuEntity();

            entity.Id = data.Id;
            entity.Main = data.Main;
            entity.Services = data.Services;
            entity.Projects = data.Projects;
            entity.Blogs = data.Blogs;
            entity.Contacts = data.Contacts;
            entity.IsPublishedOnMainPage = data.IsPublished;

            return entity;
        }
    }
}
