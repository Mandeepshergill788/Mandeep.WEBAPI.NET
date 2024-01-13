using System.ComponentModel.DataAnnotations;


namespace EveningWebAPIExample.Models
{
    public class Shirts_EnsureCorrectSizeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product != null && !string.IsNullOrWhiteSpace(product.Title))
            {
                if (product.Title.Equals("IT", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult(" This Book for IT.");
                }else if (product.Title.Equals("History", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult(" This Book for History.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
