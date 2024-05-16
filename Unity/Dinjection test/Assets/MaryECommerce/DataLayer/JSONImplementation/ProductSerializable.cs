
namespace Mary.Data
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
    }
}
