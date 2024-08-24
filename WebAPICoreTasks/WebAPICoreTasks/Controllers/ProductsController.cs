using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly db _db;

        public ProductsController(db productService)
        {
            _db = productService;
        }
        [HttpGet("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = db.GetAllProducts();
            return Ok(products); 
        }

        // 2. 
        [HttpGet("getProductById")]
        public IActionResult GetProductById([FromQuery] int id)
        {
            if (id < 1) 
            {
                return BadRequest("ID must be greater than 0");
            }

            var product = db.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product); 
        }

        // 3. 
        [HttpGet("getProductByName")]
        public IActionResult GetProductByName([FromQuery] string name, [FromQuery] int id)
        {
            if (id > 10) 
            {
                return BadRequest("ID must be less than or equal to 10");
            }

            var product = db.GetProductByName(name, id);
            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product); 
        }

        
        [HttpDelete("deleteProduct")]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            if (id < 1) 
            {
                return BadRequest("ID must be greater than 0");
            }

            var success = db.DeleteProduct(id);
            if (!success)
            {
                return NotFound(); 
            }

            return NoContent(); 
    }
}
}

