using Resources.Datas;

namespace Services.Interfaces
{
    public interface IContactService
    {
        public Task<List<ContactData>> GetAllContactDatasAsync();
        public Task<ContactData?> GetPublishedContactDataAsync();
        public Task<ContactData?> GetContactDataByIdAsync(int id);
        public Task AddContactToDbAsync(ContactData data);
        public Task EditContactToDbAsync(ContactData data);
        public Task RemoveContactToDbAsync(int id);
    }
}
