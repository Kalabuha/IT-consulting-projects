using Entities;

namespace DbRepositories.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity? Login(string login, string password);
    }
}
