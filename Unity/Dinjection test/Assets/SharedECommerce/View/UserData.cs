using UnityEngine;

namespace EComShared.View
{
    public class UserData : MonoBehaviour
    {   public static UserData Instance {get; private set;}
        public static UserData I => Instance;
        [field: SerializeField] public UserRole Role {private set; get;}

        void Awake()
        {
            Instance = this;
        }

        public bool IsInRole(UserRole role)
        {
            return role == Role;
        }

    }

    public enum UserRole
    {
        Customer,
        PreferredCustomer
    }
}