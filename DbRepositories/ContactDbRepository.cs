using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class ContactDbRepository : BaseDbRepository<ContactEntity, ContactDataModel>, IRepository<ContactDataModel>
    {
        public ContactDbRepository(DbContextProfiСonnector context)
            : base(context,
                  ContactEntityAndDataModelMapper.ContactEntityToData,
                  ContactEntityAndDataModelMapper.ContactDataToEntity)
        { }

        public async Task<ContactDataModel[]> GetAllDataModelsAsync()
        {
            var contacts = await Context.Contacts
                .Select(c => MapEntityToData(c))
                .ToArrayAsync();

            return contacts;
        }
    }
}
