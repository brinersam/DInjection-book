using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using ECom.Domain; // this is ok

namespace ECom.Data
{
    public class CommerceJSONContext : IProductRepository
    {
        string path = $"{Application.streamingAssetsPath}/Data.json";

        private string _JSONPath;

        public CommerceJSONContext(string path)
        {
            if (path == null)
            {
                Console.WriteLine("No path specified for CommerceJSONContext! Using defaults..");
                path = $"{Application.streamingAssetsPath}/Data.json";
            }
            _JSONPath = path;
        }

        public IEnumerable<Product> GetFeaturedProducts() // Func<Product, bool> predicate = null
        {
            //List<Product> result = new();

            string json = File.ReadAllText(_JSONPath);
            ProductsSerializable read = JsonUtility.FromJson<ProductsSerializable>(json);

            foreach (Product product in read)
            {
                //if (predicate == null || predicate(product))
                if (product.IsFeatured)
                    yield return product;
                    //result.Add(product);
            }
            
            //return result;
        }
    }
}