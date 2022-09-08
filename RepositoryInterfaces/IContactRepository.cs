using DataModels;

namespace RepositoryInterfaces
{
    public interface IContactRepository
    {
        public Task<ContactDataModel?> GetContactAsync(int id);
        public Task<ContactDataModel[]> GetAllContactsAsync();
        public Task<int> AddContactAsync(ContactDataModel data);
        public Task<bool> UpdateContactAsync(ContactDataModel data);
        public Task<bool> DeleteContactAsync(int id);
        
    }
}
