using Repositories.Interfaces;
using Resources.Datas;
using Services.Converters;
using Services.Interfaces;

namespace Services
{
    internal class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactData>> GetAllContactDatasAsync()
        {
            var contacts = (await _contactRepository.GetAllContactEntitiesAsync())
                .Select(c => c.ContactEntityToData())
                .ToList();

            return contacts;
        }

        public async Task<ContactData?> GetPublishedContactDataAsync()
        {
            var contact = (await _contactRepository.GetAllContactEntitiesAsync())
                .FirstOrDefault(c => c.IsPublishedOnMainPage == true);

            return contact?.ContactEntityToData();
        }

        public async Task<ContactData?> GetContactDataByIdAsync(int id)
        {
            var contact = await _contactRepository.GetEntity(id);

            return contact?.ContactEntityToData();
        }

        public async Task PublishContact(int id)
        {
            var entity = await _contactRepository.GetEntity(id);
            if (entity == null)
            {
                return;
            }

            var publishEntities = await _contactRepository.GetAllPublishedContactEntitiesAsync();
            foreach (var publishEntity in publishEntities)
            {
                publishEntity.IsPublishedOnMainPage = false;
                await _contactRepository.UpdateEntityAsync(publishEntity);
            }

            entity.IsPublishedOnMainPage = true;
            await _contactRepository.UpdateEntityAsync(entity);
        }

        public async Task<int> AddContactToDbAsync(ContactData data)
        {
            var entity = data.ContactDataToEntity();

            await _contactRepository.AddEntityAsync(entity);

            return entity.Id;
        }

        public async Task EditContactToDbAsync(ContactData data)
        {
            var entity = await _contactRepository.GetEntity(data.Id);
            if (entity == null) throw new ArgumentException($"Не найден контакт {data.Id}.", nameof(data));

            data.ContactDataToEntity(entity);

            await _contactRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveContactToDbAsync(int id)
        {
            var entity = await _contactRepository.GetEntity(id);
            if (entity != null)
            {
                await _contactRepository.RemoveEntityAsync(entity);
            }
        }
    }
}
