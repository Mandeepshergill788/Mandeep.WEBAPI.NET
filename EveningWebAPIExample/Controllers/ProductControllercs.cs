using EveningWebAPIExample.Filters;
using EveningWebAPIExample.Filters.ActionFilters;
using EveningWebAPIExample.Filters.ExceptionFilters;
using EveningWebAPIExample.Models;
using EveningWebAPIExample.Models.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace EveningWebAPIExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductControllercs : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductRepository.GetProducts());
        }
        [HttpGet("{id}")]
        [Product_ValidateProductIdFilter]
        public IActionResult GetProductById(int id)
        {
            return Ok(ProductRepository.GetProductsById(id));
        }
    
        [HttpPost]
        [product_ValidateCreateProductFilter]
        public IActionResult CreateProduct([FromForm] Product Product)
        {
            //if (product == null) return BadRequest();
            //var existingProduct = ProductRepository.GetProductByProperties(product.Tile, product.Fabric, product.Color, product.Size, product.Price);
            //if (existingProduct != null) return BadRequest();
            ProductRepository.AddProduct(Product);
            return CreatedAtAction(nameof(GetProductById),
                new { id = Product.Id },
                Product);

           // return Ok("this is to create a product");
        }
        [HttpPut("{id}")]
        [Product_ValidateProductIdFilter]
        [Product_ValidateUpdateProductFilter]
        [Product_HandleUpdateExceptionsFilter]
        public IActionResult UpdateProduct(int id, Product product)
        {
            
            ProductRepository.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Product_ValidateProductIdFilter]
        public IActionResult DeleteBook(int id)
        {
            var product = ProductRepository.GetProductsById(id);
            ProductRepository.Deleteproduct(id);
            return Ok(product);
        }

    }
}

