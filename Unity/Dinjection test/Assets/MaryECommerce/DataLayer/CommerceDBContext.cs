using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

namespace Mary.Data
{
public class CommerceDBContext
{
    private string _dbPath = $"Data Source=D:{Application.streamingAssetsPath}/DB.bytes;Version=3"; // pretend we load it from a config

    public IList<Product> DB_Read(string query = "SELECT * FROM Products")
    {
        List<Product> result = new();
        using (var conn = new SqliteConnection(_dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

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
        return result;
    }
}
}