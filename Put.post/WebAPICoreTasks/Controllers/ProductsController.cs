using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebAPICoreTasks.DTOs;
using WebAPICoreTasks.Models;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        MyDbContext _db;

        public ProductsController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            var product = _db.Products.ToList();
            return Ok(product);
        }

        // 2. 
        [HttpGet("getProductById")]
        public IActionResult GetProductById([FromQuery] int id)
        {
          
            var product = _db.Products.ToList();
            if (product == null)
            {
                return NotFound("No orders found.");
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
        [HttpGet("GetProductsBasedOnCategoryId/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsBasedOnCategoryId(int categoryId)
        {
            var products = await _db.Products
                            .Where(p => p.CategoryId == categoryId)
                            .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }
        [HttpGet("OrderByDes/")]
        public IActionResult price()
        {
            var product = _db.Products.OrderByDescending(p => p.Price).ToList();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] ProductRequest product)
        {
            if (ModelState.IsValid)
            {
                return Ok("Product added successfully");
            }
            return BadRequest("Invalid data");
        }
    }
}

