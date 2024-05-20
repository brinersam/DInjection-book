using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

using ECom.Domain; // this is ok

namespace ECom.Data
{
public class CommerceDBContext : IProductRepository
{
        //private string _dbPath = $"Data Source=D:{Application.streamingAssetsPath}/DB.bytes;Version=3";
        private string _dbPath;

        public CommerceDBContext(string path)
        {
            if (path == null)
            {
                Console.WriteLine("No path specified for CommerceDBContext! Using defaults..");
                path = $"Data Source=D:{Application.streamingAssetsPath}/DB.bytes;Version=3";
            }
            _dbPath = path;
        }

        public IEnumerable<Product> GetFeaturedProducts() //Func<Product, bool> predicate = null
        {
            List<Product> result = new();

            using (var conn = new SqliteConnection(_dbPath))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Products WHERE (IsFeatured = 1)"; // todo may be incorrect sql

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product (
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetDecimal(3),
                                    reader.GetInt32(4));

                        //if (predicate == null || predicate(product))
                            result.Add(product);
                    }
                }
            }
            return result;
        }
    }
}