using WebAppForAdmins.UserContext.Interfaces;

namespace WebAppForAdmins.UserContext
{
    public class UserContextAccessor : IUserContext
    {
        private readonly string? _userName;

        public UserContextAccessor(IHttpContextAccessor accessor)
        {
            _userName = accessor.HttpContext?.User.Identity?.Name;
        }

        public string? UserName => _userName;
    }
}
