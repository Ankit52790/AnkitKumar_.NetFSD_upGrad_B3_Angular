using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProductManagementApp.Models;
using System.Data;

namespace ProductManagementApp.Data
{
    public class ProductDAL
    {
        private readonly string _connStr;

        public ProductDAL(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }

        // Insert Methods for Create Operation
        public void InsertProduct(Product p)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get Product By ID
        public Product GetProductById(int id)
        {
            Product product = null;

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetProductById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parameter
                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = (decimal)reader["Price"]
                    };
                }
            }

            return product;
        }

        // Get All Method for getting all products
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = (decimal)reader["Price"]
                    });
                }
            }
            return list;
        }

        // Update Method for Product Update
        public void UpdateProduct(Product p)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Method for Product Deletion
        public void DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
