using EveningWebAPIExample.Models.Respositories;
using EveningWebAPIExample.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EveningWebAPIExample.Filters.ActionFilters
{
    public class product_ValidateCreateProductFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var product = context.ActionArguments["product"] as Product;
            if (product == null)
            {
                context.ModelState.AddModelError("Product", "Product object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingProduct = ProductRepository.GetProductByProperties(product.Title, product.Fabric, product.Size, product.Color, product.Price);
                if (existingProduct != null)
                {
                    context.ModelState.AddModelError("Product", " object is null.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

        }

    }
}
