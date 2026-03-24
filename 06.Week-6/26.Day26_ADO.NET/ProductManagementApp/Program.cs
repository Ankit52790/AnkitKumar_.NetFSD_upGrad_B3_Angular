using Microsoft.Extensions.Configuration;
using ProductManagementApp.Data;
using ProductManagementApp.Models;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        ProductDAL dal = new ProductDAL(config);

        while (true)
        {
            Console.WriteLine("\n1. Insert\n2. View\n3. Update\n4. Delete\n5. Get Product By Id\n6. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: // Inserting a new product
                    Product p = new Product();
                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Price: ");
                    p.Price = decimal.Parse(Console.ReadLine());

                    dal.InsertProduct(p);
                    Console.WriteLine("Inserted!");
                    break;

                case 2: // Viewing all products
                    var list = dal.GetAllProducts();
                    foreach (var item in list)
                    {
                        Console.WriteLine($"{item.ProductId} {item.ProductName} {item.Category} {item.Price}");
                    }
                    break;

                case 3: // Updating an existing product
                    Product up = new Product();
                    Console.Write("Id: ");
                    up.ProductId = int.Parse(Console.ReadLine());

                    Console.Write("New Name: ");
                    up.ProductName = Console.ReadLine();

                    Console.Write("New Category: ");
                    up.Category = Console.ReadLine();

                    Console.Write("New Price: ");
                    up.Price = decimal.Parse(Console.ReadLine());

                    dal.UpdateProduct(up);
                    Console.WriteLine("Updated!");
                    break;

                case 4: // Deleting a product
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    dal.DeleteProduct(id);
                    Console.WriteLine("Deleted!");
                    break;

                case 5: //Get product by Id
                    Console.Write("Enter Product Id: ");
                    int pid = int.Parse(Console.ReadLine());

                    var result = dal.GetProductById(pid);

                    if (result != null)
                    {
                        Console.WriteLine($"{result.ProductId} {result.ProductName} {result.Category} {result.Price}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                    break;
                case 6: // Exit
                    return;
            }
        }
    }
}
