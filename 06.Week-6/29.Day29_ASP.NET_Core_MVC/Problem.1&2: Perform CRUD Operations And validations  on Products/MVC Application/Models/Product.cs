using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Product Id is required!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required!")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Product Name must be between 5 to 15 character")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Category must be between 5 to 20 character")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

 
        public int Stock { get; set; }
    }
}
