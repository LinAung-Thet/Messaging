using Microsoft.AspNetCore.Mvc;
using ProductAPI.ProductServices;
using Shared;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await productService.AddProduct(product);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }
    }

}
