using Microsoft.Extensions.Configuration;
using ProductManagement_Disconnected.Data;
using ProductManagement_Disconnected.Models;
using System.Data;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        ProductDAL dal = new ProductDAL(config);

        while (true)
        {
            Console.WriteLine("\n1.Insert Item\n2.View Product\n3.Update Product Information\n4.Delete Item from Database\n5.Get Producut By Id\n6.Exit");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1: // Inserting a new product
                    Product p = new Product();

                    Console.Write("Product_Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Product_Price: ");
                    p.Price = decimal.Parse(Console.ReadLine());

                    dal.InsertProduct(p);
                    Console.WriteLine("Product Inserted into database!");
                    break;

                case 2: // Viewing all products
                    DataTable dt = dal.GetAllProducts();

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["ProductId"]} {row["ProductName"]} {row["Category"]} {row["Price"]}");
                    }
                    break;

                case 3: // Updating an existing product
                    Product up = new Product();

                    Console.Write("Id: ");
                    up.ProductId = int.Parse(Console.ReadLine());

                    Console.Write("Produc_Name: ");
                    up.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    up.Category = Console.ReadLine();

                    Console.Write("Product_Price: ");
                    up.Price = decimal.Parse(Console.ReadLine());

                    dal.UpdateProduct(up);
                    Console.WriteLine("Product Updated!");
                    break;

                case 4: // Deleting a product  by Id
                    Console.Write("Id: ");
                    int id = int.Parse(Console.ReadLine());

                    dal.DeleteProduct(id);
                    Console.WriteLine("Product Deleted from Database!");
                    break;
                     
                case 5: // Getting a product by Id
                    Console.Write("Enter Product Id: ");
                    int pid = int.Parse(Console.ReadLine());

                    DataTable result = dal.GetProductById(pid);

                    if (result.Rows.Count > 0)
                    {
                        foreach (DataRow row in result.Rows)
                        {
                            Console.WriteLine($"{row["ProductId"]} " +
                                              $"{row["ProductName"]}" +
                                              $" {row["Category"]}" +
                                              $" {row["Price"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product not found in Database.");
                    }
                    break;

                case 6: // Exiting the applicataion
                    return;
            }
        }
    }
}
