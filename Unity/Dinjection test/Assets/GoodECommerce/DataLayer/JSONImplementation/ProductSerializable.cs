using ECom.Domain;

namespace ECom.Data
{
    [System.Serializable]
    public struct ProductSerializable
    {
        public int id;
        public string name;
        public string description;
        public double unitPrice;
        public bool isFeatured;
        public ProductSerializable(Product product)
        {
            id = product.Id;
            name = product.Name;
            description = product.Description;
            unitPrice = (double)product.UnitPrice;
            isFeatured = product.IsFeatured;
        }

        public static implicit operator Product(ProductSerializable prod)
        {
            return new Product(
                prod.id,
                prod.name,
                prod.description,
                (decimal)prod.unitPrice,
                prod.isFeatured);
        }
    }
}
