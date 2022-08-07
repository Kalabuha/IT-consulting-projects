using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity? Login(string login, string password);
    }
}
