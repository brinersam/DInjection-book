using System.Collections;
using System.Collections.Generic;

namespace ECom.Data
{
    [System.Serializable]
    public struct ProductsSerializable : IEnumerable<ProductSerializable>
    {
        public ProductSerializable[] _products;

        public ProductsSerializable(ProductSerializable[] products)
        {
            _products = products;
        }
        public readonly IEnumerator<ProductSerializable> GetEnumerator()
        {
            foreach (ProductSerializable prod in _products)
            {
                yield return prod;
                // yield return new Product(
                //     prod.id,
                //     prod.name,
                //     prod.description,
                //     (decimal)prod.unitPrice,
                //     prod.isFeatured
                // );
            }
        }

        readonly IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
