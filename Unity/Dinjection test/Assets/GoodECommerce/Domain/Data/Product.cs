namespace ECom.Domain
{
    public struct Product
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public decimal UnitPrice {get; set;}
        public bool IsFeatured {get; set;}

        public Product(string name, string desc, decimal unitPrice, bool isFeatured) : this(-1,name,desc,unitPrice,isFeatured == false? 0 : 1) {}
        public Product(int id, string name, string desc, decimal unitPrice, bool isFeatured) : this(id,name,desc,unitPrice,isFeatured == false? 0 : 1) {}
        public Product(int id, string name, string desc, decimal unitPrice, int isFeatured)
        {
            Id = id;
            Name = name;
            Description = desc;
            UnitPrice = unitPrice;
            IsFeatured = isFeatured != 0;
        }
        public override readonly string ToString()
        {
            return $"Id {Id}\nName:{Name}\nDescription:{Description}\nUnitPrice:{UnitPrice}\nIsFeatured:{IsFeatured}\n";
        }
    }
}