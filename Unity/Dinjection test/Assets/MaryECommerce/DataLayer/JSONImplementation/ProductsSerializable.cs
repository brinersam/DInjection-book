using System.Collections;
using System.Collections.Generic;

namespace Mary.Data
{
    [System.Serializable]
    public struct ProductsSerializable : IEnumerable<Product>
    {
        public ProductSerializable[] _products;

        public ProductsSerializable(ProductSerializable[] products)
        {
            _products = products;
        }
        public readonly IEnumerator<Product> GetEnumerator()
        {
            foreach (ProductSerializable prod in _products)
            {
                yield return new Product(
                    prod.id,
                    prod.name,
                    prod.description,
                    (decimal)prod.unitPrice,
                    prod.isFeatured
                );
            }
        }

        readonly IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
