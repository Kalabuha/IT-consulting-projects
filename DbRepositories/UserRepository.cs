using DbRepositories.Base;
using RepositoryInterfaces;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContextProfiСonnector context) : base(context) {}

        public UserEntity? Login(string login, string password)
        {
            var user = Context.Users.FirstOrDefault(x => x.Login == login);
            if (user == null)
                return null;

            var passwordHash = UserEntity.CreatePasswordHash(password, user.PasswordSalt);
            if (passwordHash != user.PasswordHash)
                return null;

            var role = Context.Roles.FirstOrDefault(r => r.Id == user.RoleId);
            user.Role = role;

            return user;
        }
    }
}
