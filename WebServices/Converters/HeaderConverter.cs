using Entities;
using WebModels;
using DataModels;

namespace WebServices.Converters
{
    public static class HeaderConverter
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
