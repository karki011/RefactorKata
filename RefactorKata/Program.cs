using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO add connection config when its taught 
            using (var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();
                var products = new List<Product>();

                //TODO: Replace with Dapper once taught
                while (reader.Read())
                {
                    products.Add(new Product { Name = reader["Name"].ToString() });
                }

                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }
    }
}
