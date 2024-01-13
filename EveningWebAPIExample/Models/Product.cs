using System.ComponentModel.DataAnnotations;

namespace EveningWebAPIExample.Models
{
    public class Product
    {
        public Product() { }

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Fabric { get; set; }

        [Shirts_EnsureCorrectSize]
        public string? Color { get; set; }
        [Required]

        public string? Size { get; set; }
        [Required]

        public int? Price { get; set; }

        internal static bool Any(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
