using System.Globalization;
using ECom.Domain;
using EComShared.View;

namespace ECom.MVVM
{
    public class UserContextAdapter : IUserContext
    {
        private readonly UserData _userData;
        public CultureInfo CultureInfo => _userData.Culture;

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