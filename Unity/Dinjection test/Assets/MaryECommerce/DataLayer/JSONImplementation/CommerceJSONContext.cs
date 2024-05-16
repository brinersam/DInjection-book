using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Mary.Data
{
public class CommerceJSONContext
{
    string path = $"{Application.streamingAssetsPath}/Data.json";

    public IList<Product> JSON_Read(Func<Product,bool> predicate = null)
    {
        List<Product> result = new();

        string json = File.ReadAllText(path);
        ProductsSerializable read = JsonUtility.FromJson<ProductsSerializable>(json);

        foreach(Product i in read)
        {
            if (predicate is null)
            {
                result.Add(i);
            }
            else
            {
                if (predicate(i))
                    result.Add(i);
            }
        }

        return result;
    }
}
}