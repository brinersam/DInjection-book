namespace ECom.Domain
{
    public struct UserInfo
    {
        public bool IsPreferred {get;}
        public UserInfo (bool isCustomerPreferred)
        {
            IsPreferred = isCustomerPreferred;
        }
    }
}