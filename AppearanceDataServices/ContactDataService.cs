using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;

namespace AppearanceDataServices
{
    internal class ContactDataService : IContactService
    {
        private readonly IRepository<ContactDataModel> _contactRepository;

        public ContactDataService(IRepository<ContactDataModel> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactDataModel?> GetContactDataByIdAsync(int id)
        {
            var contact = await _contactRepository.GetDataModelAsync(id);

            return contact;
        }

        public async Task<List<ContactDataModel>> GetAllContactDatasAsync()
        {
            var contacts = (await _contactRepository.GetAllDataModelsAsync())
                .ToList();

            return contacts;
        }

        public async Task<ContactDataModel?> GetPublishedContactDataAsync()
        {
            var contact = (await _contactRepository.GetAllDataModelsAsync())
                .FirstOrDefault(c => c.IsPublished);

            return contact;
        }

        public async Task PublishContact(int id)
        {
            var publishedContact = await _contactRepository.GetDataModelAsync(id);
            if (publishedContact == null)
            {
                return;
            }

            var contacts = await _contactRepository.GetAllDataModelsAsync();
            foreach (var contact in contacts)
            {
                if (contact.Id == id)
                {
                    contact.IsPublished = true;
                }
                else
                {
                    if (contact.IsPublished)
                    {
                        contact.IsPublished = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                await _contactRepository.UpdateDataModelAsync(contact);
            }
        }

        public async Task<int> AddContactToDbAsync(ContactDataModel? data)
        {
            if (data != null)
            {
                var newContact = await _contactRepository.AddDataModelAsync(data);
                return newContact.Id;
            }

            return 0;
        }

        public async Task EditContactToDbAsync(ContactDataModel? data)
        {
            if (data != null)
            {
                await _contactRepository.UpdateDataModelAsync(data);
            }
        }

        public async Task RemoveContactToDbAsync(int id)
        {
            if (id > 0)
            {
                await _contactRepository.DeleteDataModelAsync(id);
            }
        }
    }
}
