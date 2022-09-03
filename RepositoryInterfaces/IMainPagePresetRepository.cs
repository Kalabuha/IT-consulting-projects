﻿using Entities;

namespace RepositoryInterfaces
{
    public interface IMainPagePresetRepository : IRepository<MainPagePresetEntity>
    {
        public Task<MainPagePresetEntity[]> GetAllMainPagePresetEntitiesAsync();
        public Task<MainPagePresetEntity[]> GetAllPublishedPresetEntityAsync();
        public Task<MainPagePresetEntity?> GetPublishedMainPagePresetEntityAsync();
    }
}