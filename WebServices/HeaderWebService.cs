using RepositoryInterfaces;
using ServiceInterfaces;
using EntitiesDataModelsConverters;
using WebServices.Common;
using DataModels;
using WebModels;
using Entities;

namespace WebServices
{
    internal class HeaderWebService : DefaultDataService, IHeaderService
    {
        private readonly IHeaderMenuSetRepository _menuRepository;
        private readonly IHeaderSloganRepository _sloganRepository;

        private readonly Random _random;

        public HeaderWebService(IHeaderMenuSetRepository menuRepository, IHeaderSloganRepository sloganRepository)
        {
            _menuRepository = menuRepository;
            _sloganRepository = sloganRepository;

            _random = new Random();
        }

        public async Task<List<MenuData>> GetAllMenuDatasAsync()
        {
            var entities = await _menuRepository.GetAllMenuEntitiesAsync();
            var datas = entities.Select(m => m.MenuEntityToData())
                .ToList();

            return datas;
        }

        public async Task<MenuData> GetUsedMenuDataAsync()
        {
            var entity = await _menuRepository.GetUsedMenuEntityAsync();
            entity ??= new MenuEntity
            {
                Id = 0,
                Main = nameof(MenuModel.Main),
                Services = nameof(MenuModel.Services),
                Projects = nameof(MenuModel.Projects),
                Blogs = nameof(MenuModel.Blogs),
                Contacts = nameof(MenuModel.Contacts),
                IsPublishedOnMainPage = true
            };

            var data = entity.MenuEntityToData();

            return data;
        }

        public async Task StartUsingMenuAsync(int id)
        {
            var newUsedMenu = await _menuRepository.GetEntityAsync(id);
            if (newUsedMenu == null)
            {
                return;
            }

            var allMenus = await _menuRepository.GetAllMenuEntitiesAsync();
            foreach (var menu in allMenus)
            {
                if (menu.IsPublishedOnMainPage)
                {
                    menu.IsPublishedOnMainPage = false;
                }

                await _menuRepository.UpdateEntityAsync(menu);
            }

            newUsedMenu.IsPublishedOnMainPage = true;
            await _menuRepository.UpdateEntityAsync(newUsedMenu);
        }

        public async Task AddMenuToDbAsync(MenuData data)
        {
            var entity = data.MenuDataToEntity();

            await _menuRepository.AddEntityAsync(entity);
        }

        public async Task EditMenuToDbAsync(MenuData data)
        {
            var entity = await _menuRepository.GetEntityAsync(data.Id);
            if (entity == null) throw new ArgumentException($"Не найдено меню {data.Id}.", nameof(data));

            data.MenuDataToEntity(entity);

            await _menuRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveMenuToDbAsync(int id)
        {
            var entity = await _menuRepository.GetEntityAsync(id);
            if (entity != null)
            {
                await _menuRepository.RemoveEntityAsync(entity.Id);
            }
        }

        public async Task<SloganData> GetRandomSloganDataAsync()
        {
            var allSloganEntities = await _sloganRepository.GetSloganEntitiesAsync();
            var randomSloganEntity = allSloganEntities.Length > 0 ? allSloganEntities[_random.Next(allSloganEntities.Length)] : null;

            randomSloganEntity ??= new SloganEntity
            {
                Id = 0,
                Slogan = await GetDefaultTextFromFileAsync("slogan.txt"),
                IsUsed = true
            };

            var randomSloganData = randomSloganEntity.SloganEntityToData();

            return randomSloganData;
        }

        public async Task<string> GetDefaultSloganContent()
        {
            var defaultSloganContent = await GetDefaultTextFromFileAsync("slogan.txt");

            return defaultSloganContent;
        }

        public async Task<List<SloganData>> GetAllSloganDatasAsync()
        {
            var entities = await _sloganRepository.GetAllSloganEntitiesAsync();
            var datas = entities.Select(s => s.SloganEntityToData())
                .ToList();

            return datas;
        }

        public async Task StartUsingSlogansAsync(int[] slogansId)
        {
            if (slogansId == null)
            {
                return;
            }

            var allSlogans = await _sloganRepository.GetAllSloganEntitiesAsync();
            foreach (var slogan in allSlogans)
            {
                if (slogansId.Contains(slogan.Id))
                {
                    slogan.IsUsed = true;
                }
                else
                {
                    if (!slogan.IsUsed)
                    {
                        continue;
                    }

                    slogan.IsUsed = false;
                }

                await _sloganRepository.UpdateEntityAsync(slogan);
            }
        }

        public async Task<SloganData?> GetSloganDataByIdAsync(int id)
        {
            var entity = await _sloganRepository.GetEntityAsync(id);
            if (entity == null) 
            {
                return null;
            }

            var data = entity.SloganEntityToData();
            return data;
        }

        public async Task AddSloganToDbAsync(SloganData data)
        {
            var entity = data.SloganDataToEntity();

            await _sloganRepository.AddEntityAsync(entity);
        }

        public async Task EditSloganToDbAsync(SloganData data)
        {
            var entity = await _sloganRepository.GetEntityAsync(data.Id);
            if (entity == null) throw new ArgumentException($"Не найден слоган {data.Id}.", nameof(data));

            data.SloganDataToEntity(entity);

            await _sloganRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveSloganToDbAsync(int id)
        {
            var entity = await _sloganRepository.GetEntityAsync(id);
            if (entity != null)
            {
                await _sloganRepository.RemoveEntityAsync(entity.Id);
            }
        }
    }
}

