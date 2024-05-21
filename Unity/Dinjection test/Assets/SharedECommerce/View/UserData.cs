using System.Globalization;
using UnityEngine;

namespace EComShared.View
{
    public class UserData : MonoBehaviour
    {   public static UserData Instance {get; private set;}

        [SerializeField] private string _cultureString = "en-US";


        public static UserData I => Instance;
        [field: SerializeField] public UserRole Role {private set; get;}
        public CultureInfo Culture => new(_cultureString);

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