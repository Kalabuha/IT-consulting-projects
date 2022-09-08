using DataModels;

namespace ServiceInterfaces
{
    public interface IContactService
    {
        public Task<List<ContactDataModel>> GetAllContactDatasAsync();
        public Task<ContactDataModel?> GetPublishedContactDataAsync();
        public Task<ContactDataModel?> GetContactDataByIdAsync(int id);
        public Task PublishContact(int id);

        public Task<int> AddContactToDbAsync(ContactDataModel? data);
        public Task EditContactToDbAsync(ContactDataModel? data);
        public Task RemoveContactToDbAsync(int id);
    }
}
