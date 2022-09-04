using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class ContactDbRepository : BaseDbRepository<ContactEntity>, IContactRepository
    {
        public ContactDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ContactEntity[]> GetAllContactEntitiesAsync()
        {
            var contacts = await Context.Contacts
                .ToArrayAsync();

            return contacts;
        }

        public async Task<ContactEntity[]> GetAllPublishedContactEntitiesAsync()
        {
            var contacts = await Context.Contacts
                .Where(c => c.IsPublishedOnMainPage)
                .ToArrayAsync();

            return contacts;
        }
    }
}
