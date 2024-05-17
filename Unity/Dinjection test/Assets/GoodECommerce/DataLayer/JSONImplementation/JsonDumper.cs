using System.IO;
using System.Linq;
using UnityEngine;

namespace ECom.Data
{
    public static class JsonDumper
    {
        // public static void DumpToJSON(ProductSerializable[] products)
        // {
        //     DumpToJSON(null, products);
        // }
        
        public static void DumpToJSON(string path, ProductSerializable[] products)
        {
            if (path == null)
                path = $"{Application.streamingAssetsPath}/Data.json";

            ProductsSerializable data = new(products.Select(x => new ProductSerializable(x)).ToArray());

            string json = JsonUtility.ToJson(data, true);

            File.WriteAllText(path, json);
        }
    }
}