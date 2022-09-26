using RepositoryInterfaces;
using ServiceInterfaces;
using DefaultDataServices;
using DataModels;

namespace AppearanceDataServices
{
    internal class MainPageHeaderDataService : DefaultDataService, IHeaderService
    {
        private readonly IRepository<HeaderMenuDataModel> _headerMenuRepository;
        private readonly IRepository<HeaderSloganDataModel> _sloganRepository;

        private readonly Random _random;

        public MainPageHeaderDataService(IRepository<HeaderMenuDataModel> menuRepository, IRepository<HeaderSloganDataModel> sloganRepository)
        {
            _headerMenuRepository = menuRepository;
            _sloganRepository = sloganRepository;

            _random = new Random();
        }

        public async Task<List<HeaderMenuDataModel>> GetAllHeaderMenuDatasAsync()
        {
            var headerMenusArray = await _headerMenuRepository.GetAllDataModelsAsync();
            var headerMenusList = headerMenusArray.ToList();

            return headerMenusList;
        }

        public async Task<HeaderMenuDataModel> GetUsedOrDefaultHeaderMenuDataAsync()
        {
            var headerMenusArray = await _headerMenuRepository.GetAllDataModelsAsync();
            var usedHeaderMenu = headerMenusArray.FirstOrDefault(m => m.IsPublished);

            usedHeaderMenu ??= new HeaderMenuDataModel
            {
                Id = 0,
                Main = nameof(HeaderMenuDataModel.Main),
                Services = nameof(HeaderMenuDataModel.Services),
                Projects = nameof(HeaderMenuDataModel.Projects),
                Blogs = nameof(HeaderMenuDataModel.Blogs),
                Contacts = nameof(HeaderMenuDataModel.Contacts),
                IsPublished = true
            };

            return usedHeaderMenu;
        }

        public async Task StartUsingHeaderMenuAsync(int id)
        {
            var usedMenu = await _headerMenuRepository.GetDataModelAsync(id);
            if (usedMenu == null)
            {
                return;
            }

            var menus = await _headerMenuRepository.GetAllDataModelsAsync();
            foreach (var menu in menus)
            {
                if (menu.Id == id)
                {
                    menu.IsPublished = true;
                }
                else
                {
                    if (menu.IsPublished)
                    {
                        menu.IsPublished = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                await _headerMenuRepository.UpdateDataModelAsync(menu);
            }
        }

        public async Task AddMenuToDbAsync(HeaderMenuDataModel? data)
        {
            if (data != null)
            {
                await _headerMenuRepository.AddDataModelAsync(data);
            }
        }

        public async Task EditMenuToDbAsync(HeaderMenuDataModel? data)
        {
            if (data != null)
            {
                await _headerMenuRepository.UpdateDataModelAsync(data);
            }
        }

        public async Task RemoveMenuToDbAsync(int id)
        {
            if (id > 0)
            {
                await _headerMenuRepository.DeleteDataModelAsync(id);
            }
        }

        public async Task<HeaderSloganDataModel?> GetHeaderSloganDataByIdAsync(int id)
        {
            var slogan = await _sloganRepository.GetDataModelAsync(id);

            return slogan;
        }

        public async Task<List<HeaderSloganDataModel>> GetAllHeaderSloganDatasAsync()
        {
            var slogans = (await _sloganRepository.GetAllDataModelsAsync())
                .ToList();

            return slogans;
        }

        public async Task<HeaderSloganDataModel> GetRandomOrDefaultHeaderSloganDataAsync(string startPathToDefaultData)
        {
            var allSlogans = await _sloganRepository.GetAllDataModelsAsync();

            var usedSlogans = allSlogans
                .Where(s => s.IsUsed)
                .ToArray();

            var randomSlogan = usedSlogans.Length > 0 ? usedSlogans[_random.Next(usedSlogans.Length)] : null;

            randomSlogan ??= new HeaderSloganDataModel
            {
                Id = 0,
                Slogan = await GetDefaultTextFromFileAsync(startPathToDefaultData, "slogan.txt"),
                IsUsed = true
            };

            return randomSlogan;
        }

        public async Task StartUsingHeaderSlogansAsync(int[] slogansId)
        {
            if (slogansId == null)
            {
                return;
            }

            var allSlogans = await _sloganRepository.GetAllDataModelsAsync();
            foreach (var slogan in allSlogans)
            {
                if (slogansId.Contains(slogan.Id))
                {
                    if (slogan.IsUsed)
                    {
                        continue;
                    }
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
                await _sloganRepository.UpdateDataModelAsync(slogan);
            }
        }

        public async Task AddSloganToDbAsync(HeaderSloganDataModel? data)
        {
            if (data != null)
            {
                await _sloganRepository.AddDataModelAsync(data);
            }
        }

        public async Task EditSloganToDbAsync(HeaderSloganDataModel? data)
        {
            if (data != null)
            {
                await _sloganRepository.UpdateDataModelAsync(data);
            }
        }

        public async Task RemoveSloganToDbAsync(int id)
        {
            if (id > 0)
            {
                await _sloganRepository.DeleteDataModelAsync(id);
            }
        }

        public async Task<string> GetDefaultSloganContent(string startPathToDefaultData)
        {
            var defaultSloganContent = await GetDefaultTextFromFileAsync(startPathToDefaultData, "slogan.txt");

            return defaultSloganContent;
        }
    }
}

