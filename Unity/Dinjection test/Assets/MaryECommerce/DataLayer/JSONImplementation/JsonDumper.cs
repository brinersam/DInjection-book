using System.IO;
using System.Linq;
using UnityEngine;

namespace Mary.Data
{
    public static class JsonDumper
    {
        public static void DumpToJSON(Product[] products)
        {
            DumpToJSON(null, products);
        }
        public static void DumpToJSON(string path, Product[] products)
        {
            if (path == null)
                path = $"{Application.streamingAssetsPath}/Data.json";

            ProductsSerializable data = new(products.Select(x => x.Serialize()).ToArray());

            string json = JsonUtility.ToJson(data, true);

            File.WriteAllText(path, json);
        }
    }
}