using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProductManagement_Disconnected.Models;
using System.Data;

// Data Access Layer (DAL) for Product Management
namespace ProductManagement_Disconnected.Data
{
    public class ProductDAL
    {
         //
        private readonly string _connStr;

        public ProductDAL(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }

        // Get by Id  (Disconnected) 
        public DataTable GetProductById(int id)
        {
            using SqlConnection con = new SqlConnection(_connStr);

            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetProductById", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            // Add parameter for the stored procedure
            adapter.SelectCommand.Parameters.AddWithValue("@ProductId", id);

            DataTable dt = new DataTable();
            adapter.Fill(dt); // fills data & closes connection auto

            return dt;
        }

        // GET ALL (Disconnected)
        public DataTable GetAllProducts()
        {
            using SqlConnection con = new SqlConnection(_connStr);

            SqlDataAdapter adapter = new SqlDataAdapter("sp_GetAllProducts", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            adapter.Fill(dt); // Fill data and close connection automatically

            return dt;
        }

        // Insert product (Disconnected)
        public void InsertProduct(Product p)
        {
            using SqlConnection con = new SqlConnection(_connStr);

            // Create a SqlDataAdapter and set the InsertCommand
            SqlDataAdapter adapter = new SqlDataAdapter();
             
            // Define the InsertCommand with the stored procedure and parameters
            adapter.InsertCommand = new SqlCommand("sp_InsertProduct", con);
            //
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            //
            adapter.InsertCommand.Parameters.AddWithValue("@ProductName", p.ProductName);
            adapter.InsertCommand.Parameters.AddWithValue("@Category", p.Category);
            adapter.InsertCommand.Parameters.AddWithValue("@Price", p.Price);

            con.Open();
            adapter.InsertCommand.ExecuteNonQuery();
        }

        // UPDATE
        public void UpdateProduct(Product p)
        {
            using SqlConnection con = new SqlConnection(_connStr);

            SqlDataAdapter adapter = new SqlDataAdapter();
            //
            adapter.UpdateCommand = new SqlCommand("sp_UpdateProduct", con);
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            adapter.UpdateCommand.Parameters.AddWithValue("@ProductId", p.ProductId);
            adapter.UpdateCommand.Parameters.AddWithValue("@ProductName", p.ProductName);
            adapter.UpdateCommand.Parameters.AddWithValue("@Category", p.Category);
            adapter.UpdateCommand.Parameters.AddWithValue("@Price", p.Price);

            con.Open();
            adapter.UpdateCommand.ExecuteNonQuery();
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            using SqlConnection con = new SqlConnection(_connStr);

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.DeleteCommand = new SqlCommand("sp_DeleteProduct", con);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            adapter.DeleteCommand.Parameters.AddWithValue("@ProductId", id);

            con.Open();
            adapter.DeleteCommand.ExecuteNonQuery();
        }
    }
}
