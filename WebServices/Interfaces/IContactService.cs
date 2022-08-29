using DataModels;

namespace WebServices.Interfaces
{
    public interface IContactService
    {
        public Task<List<ContactData>> GetAllContactDatasAsync();
        public Task<ContactData?> GetPublishedContactDataAsync();
        public Task<ContactData?> GetContactDataByIdAsync(int id);
        public Task PublishContact(int id);

        public Task<int> AddContactToDbAsync(ContactData data);
        public Task EditContactToDbAsync(ContactData data);
        public Task RemoveContactToDbAsync(int id);
    }
}
