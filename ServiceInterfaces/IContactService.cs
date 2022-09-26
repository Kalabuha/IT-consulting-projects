using DataModels;

namespace ServiceInterfaces
{
    public interface IContactService
    {
        Task<List<ContactDataModel>> GetAllContactDatasAsync();
        Task<ContactDataModel?> GetPublishedContactDataAsync();
        Task<ContactDataModel?> GetContactDataByIdAsync(int id);
        Task PublishContact(int id);

        Task<int> AddContactToDbAsync(ContactDataModel? data);
        Task EditContactToDbAsync(ContactDataModel? data);
        Task RemoveContactToDbAsync(int id);
    }
}
