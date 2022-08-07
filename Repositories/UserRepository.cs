using Repositories.Base;
using Repositories.Interfaces;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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

            return user;
        }
    }
}
