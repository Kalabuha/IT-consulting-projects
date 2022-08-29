using Microsoft.EntityFrameworkCore;
using DbRepositories.Interfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class ContactRepository : BaseRepository<ContactEntity>, IContactRepository
    {
        public ContactRepository(DbContextProfiСonnector context) : base(context) { }

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
