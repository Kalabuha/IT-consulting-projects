using Entities;

namespace RepositoryInterfaces
{
    public interface IUserRepository
    {
        public UserEntity? Login(string login, string password);
    }
}
