namespace Mary.Data
{
public struct Product
{
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string Description {get; private set;}
    public decimal UnitPrice {get; set;}
    public bool IsFeatured {get; private set;}

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

    public readonly ProductSerializable Serialize()
    {
        return new ProductSerializable(this);
    }
    public override readonly string ToString()
    {
        return $"Id {Id}\nName:{Name}\nDescription:{Description}\nUnitPrice:{UnitPrice}\nIsFeatured:{IsFeatured}\n";
    }
}
}