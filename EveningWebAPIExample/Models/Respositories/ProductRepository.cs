using System.Drawing;
using System.ComponentModel.DataAnnotations;
namespace EveningWebAPIExample.Models.Respositories
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>() 
        {
        new Product{Id = 1,Title = "Kurta", Fabric = "Cotton",  Color = "Purple", Size = "M", Price = 300},
        new Product{Id = 2,Title = "Dress", Fabric = "Georgette",Color = "Brown", Size = "M",  Price = 150},
        new Product{Id = 3,Title = "Anarkali", Fabric = "Crepe",Color = "Peach", Size = "L" , Price = 125},
        new Product{Id = 4,Title = "Cord Set", Fabric = "Silk",Color = "Khaki", Size = "S" , Price = 250},
        new Product{Id = 5,Title = "Suit", Fabric = "Silk", Color = "Blue", Size = "XL", Price = 100}

        };
        public static List<Product> GetProducts()
        {
            return products;
        }
        public static bool ProductExists(int id)
        {
            return products.Any(p => p.Id == id);
        }
        public static Product? GetProductsById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
        public static Product? GetProductByProperties(string? title,string? fabric, string?color, string? size, int? price)
        {
            return products.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(title) &&
            !string.IsNullOrWhiteSpace(x.Title) &&
            x.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(fabric) &&
            !string.IsNullOrWhiteSpace(x.Fabric) &&
            x.Fabric.Equals(fabric, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(size) &&
            !string.IsNullOrWhiteSpace(x.Size) &&
            x.Size.Equals(size, StringComparison.OrdinalIgnoreCase) &&
            price.HasValue &&
            x.Price.HasValue &&
            price.Value == x.Price.Value
            );
        }
        public static void AddProduct(Product product)
        {
            int maxId = products.Max(x => x.Id);
            product.Id = maxId + 1;
            products.Add(product);
        }
        public static void UpdateProduct(Product product)
        {
            var productToUpdate = products.First(x => x.Id == product.Id);
            productToUpdate.Title  = product.Title;
            productToUpdate.Price = product.Price;
            productToUpdate.Fabric = product.Fabric;
            productToUpdate.Color = product.Color;
            productToUpdate.Size = product.Size;
            //productToUpdate.Title = product.Title;


        }
        public static void Deleteproduct(int Id)
        {
            var product = GetProductsById(Id);
            if (product != null)
            {
                products.Remove((Product )product);
            }
            
        }

    }
}
