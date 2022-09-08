using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;

namespace AppearanceDataServices
{
    internal class ContactDataService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactDataService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactDataModel?> GetContactDataByIdAsync(int id)
        {
            var contact = await _contactRepository.GetContactAsync(id);

            return contact;
        }

        public async Task<List<ContactDataModel>> GetAllContactDatasAsync()
        {
            var contacts = (await _contactRepository.GetAllContactsAsync())
                .ToList();

            return contacts;
        }

        public async Task<ContactDataModel?> GetPublishedContactDataAsync()
        {
            var contact = (await _contactRepository.GetAllContactsAsync())
                .FirstOrDefault(c => c.IsPublished);

            return contact;
        }

        public async Task PublishContact(int id)
        {
            var publishedContact = await _contactRepository.GetContactAsync(id);
            if (publishedContact == null)
            {
                return;
            }

            var contacts = await _contactRepository.GetAllContactsAsync();
            foreach (var contact in contacts)
            {
                if (contact.IsPublished && contact.Id != publishedContact.Id)
                {
                    contact.IsPublished = false;
                    await _contactRepository.UpdateContactAsync(contact);
                }
            }

            publishedContact.IsPublished = true;
            await _contactRepository.UpdateContactAsync(publishedContact);
        }

        public async Task<int> AddContactToDbAsync(ContactDataModel? data)
        {
            if (data != null)
            {
                return await _contactRepository.AddContactAsync(data);
            }

            return 0;
        }

        public async Task EditContactToDbAsync(ContactDataModel? data)
        {
            if (data != null)
            {
                await _contactRepository.UpdateContactAsync(data);
            }
        }

        public async Task RemoveContactToDbAsync(int id)
        {
            if (id > 0)
            {
                await _contactRepository.DeleteContactAsync(id);
            }
        }
    }
}
