using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class CommerceDBContext : MonoBehaviour
{
    void Start()
    {
        string DBPATH = $"Data Source=D:{Application.streamingAssetsPath}/DB.bytes;Version=3";
        CreateSchema(DBPATH);
    }

    private void CreateSchema(string path)
    {
        List<Product> result = new();
        using (var conn = new SqliteConnection(path))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Products";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   result.Add(new Product (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4)));
                }
            }
        }
        foreach(var i in result)
        {
            Debug.Log(i);
        }
    }
}
