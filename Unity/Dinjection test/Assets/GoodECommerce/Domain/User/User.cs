using System.Globalization;

namespace ECom.Domain
{
    public enum UserRole
    {
        Customer,
        PreferredCustomer
    }

    public interface IUserContext
    {
        public bool IsInRole(UserRole role);
        public CultureInfo CultureInfo {get;}
    }
}