using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class ContactDbRepository : BaseDbRepository<ContactEntity>, IContactRepository
    {
        public ContactDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ContactDataModel?> GetContactAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.ContactEntityToData();
        }

        public async Task<ContactDataModel[]> GetAllContactsAsync()
        {
            var contacts = await Context.Contacts
                .Select(c => c.ContactEntityToData())
                .ToArrayAsync();

            return contacts;
        }

        public async Task<int> AddContactAsync(ContactDataModel data)
        {
            var entity = data.ContactDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateContactAsync(ContactDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.ContactDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity == null)
            {
                return false;
            }

            await RemoveEntityAsync(entity);
            return true;
        }
    }
}
