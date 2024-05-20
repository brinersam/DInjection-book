using ECom.Domain;
using EComShared.View;

namespace ECom.MVVM
{
    public class UserContextAdapter : IUserContext
    {
        private UserData _userData;

        public UserContextAdapter()
        {
            _userData = UserData.Instance;
        }

        public bool IsInRole(Domain.UserRole role)
        {
            return (int)_userData.Role == (int)role;
        }
    }
}