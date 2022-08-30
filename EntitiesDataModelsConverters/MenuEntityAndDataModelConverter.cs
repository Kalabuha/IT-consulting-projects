using Entities;
using DataModels;

namespace EntitiesDataModelsConverters
{
    public static class MenuEntityAndDataModelConverter
    {
        public static MenuData MenuEntityToData(this MenuEntity entity)
        {
            return new MenuData
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

        public static MenuEntity MenuDataToEntity(this MenuData data, MenuEntity? entity = null)
        {
            entity ??= new MenuEntity();

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
