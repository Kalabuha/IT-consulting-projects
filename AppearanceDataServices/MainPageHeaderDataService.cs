using RepositoryInterfaces;
using ServiceInterfaces;
using DefaultDataServices;
using DataModels;
using Entities;

namespace AppearanceDataServices
{
    internal class MainPageHeaderDataService : DefaultDataService, IHeaderService
    {
        private readonly IHeaderMenuRepository _headerMenuRepository;
        private readonly IHeaderSloganRepository _sloganRepository;

        private readonly Random _random;

        public MainPageHeaderDataService(IHeaderMenuRepository menuRepository, IHeaderSloganRepository sloganRepository)
        {
            _headerMenuRepository = menuRepository;
            _sloganRepository = sloganRepository;

            _random = new Random();
        }

        public async Task<List<HeaderMenuDataModel>> GetAllHeaderMenuDatasAsync()
        {
            var headerMenusArray = await _headerMenuRepository.GetAllHeaderMenusAsync();
            var headerMenusList = headerMenusArray.ToList();

            return headerMenusList;
        }

        public async Task<HeaderMenuDataModel> GetUsedHeaderMenuDataAsync()
        {
            var headerMenusArray = await _headerMenuRepository.GetAllHeaderMenusAsync();
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
            var newUsedHeaderMenu = await _headerMenuRepository.GetHeaderMenuAsync(id);
            if (newUsedHeaderMenu == null)
            {
                return;
            }

            var allHeaderMenus = await _headerMenuRepository.GetAllHeaderMenusAsync();
            foreach (var headerMenu in allHeaderMenus)
            {
                if (headerMenu.IsPublished)
                {
                    headerMenu.IsPublished = false;
                }

                await _headerMenuRepository.UpdateHeaderMenuAsync(headerMenu);
            }

            newUsedHeaderMenu.IsPublished = true;
            await _headerMenuRepository.UpdateHeaderMenuAsync(newUsedHeaderMenu);
        }

        public async Task AddMenuToDbAsync(HeaderMenuDataModel? data)
        {
            if (data != null)
            {
                await _headerMenuRepository.AddHeaderMenuAsync(data);
            }
        }

        public async Task EditMenuToDbAsync(HeaderMenuDataModel? data)
        {
            if (data != null)
            {
                await _headerMenuRepository.UpdateHeaderMenuAsync(data);
            }
        }

        public async Task RemoveMenuToDbAsync(int id)
        {
            if (id > 0)
            {
                await _headerMenuRepository.DeleteHeaderMenuAsync(id);
            }
        }

        public async Task<HeaderSloganDataModel?> GetHeaderSloganDataByIdAsync(int id)
        {
            var slogan = await _sloganRepository.GetHeaderSloganAsync(id);

            return slogan;
        }

        public async Task<List<HeaderSloganDataModel>> GetAllHeaderSloganDatasAsync()
        {
            var slogans = (await _sloganRepository.GetAllHeaderSlogansAsync())
                .ToList();

            return slogans;
        }

        public async Task<HeaderSloganDataModel> GetRandomOrDefaultHeaderSloganDataAsync()
        {
            var allSlogans = await _sloganRepository.GetAllHeaderSlogansAsync();
            var randomSlogan = allSlogans.Length > 0 ? allSlogans[_random.Next(allSlogans.Length)] : null;

            randomSlogan ??= new HeaderSloganDataModel
            {
                Id = 0,
                Slogan = await GetDefaultTextFromFileAsync("slogan.txt"),
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

            var allSlogans = await _sloganRepository.GetAllHeaderSlogansAsync();
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

                await _sloganRepository.UpdateHeaderSloganAsync(slogan);
            }
        }

        public async Task AddSloganToDbAsync(HeaderSloganDataModel? data)
        {
            if (data != null)
            {
                await _sloganRepository.AddHeaderSloganAsync(data);
            }
        }

        public async Task EditSloganToDbAsync(HeaderSloganDataModel? data)
        {
            if (data != null)
            {
                await _sloganRepository.UpdateHeaderSloganAsync(data);
            }
        }

        public async Task RemoveSloganToDbAsync(int id)
        {
            if (id > 0)
            {
                await _sloganRepository.DeleteHeaderSloganAsync(id);
            }
        }

        public async Task<string> GetDefaultSloganContent()
        {
            var defaultSloganContent = await GetDefaultTextFromFileAsync("slogan.txt");

            return defaultSloganContent;
        }
    }
}

