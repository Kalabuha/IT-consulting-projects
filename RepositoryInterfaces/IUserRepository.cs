using Entities;

namespace RepositoryInterfaces
{
    public interface IUserRepository
    {
        UserEntity? Login(string login, string password);
    }
}
