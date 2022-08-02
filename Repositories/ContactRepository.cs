using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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
    }
}
