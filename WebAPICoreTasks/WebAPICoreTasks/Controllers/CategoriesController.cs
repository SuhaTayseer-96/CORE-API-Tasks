using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTasks.Models;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
            MyDbContext _db;

            public CategoriesController(MyDbContext db)
            {
                _db = db;
            }
        [HttpGet("getAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _db.GetAllOrders();
            if (orders == null)
            {
                return NotFound("No orders found.");
            }

            return Ok(orders);
        }

        // 2. 
        [HttpGet("getOrderById")]
        public IActionResult GetOrderById([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }

            var order = _db.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }

        // 3. 
        [HttpGet("getOrderByName")]
        public IActionResult GetOrderByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be null or empty.");
            }

            var order = _db.GetOrderByName(name);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }

        // 4. 
        [HttpDelete("deleteOrder")]
        public IActionResult DeleteOrder([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }

            var success = _db.DeleteOrder(id);
            if (!success)
            {
                return NotFound("Order not found.");
            }

            return NoContent();
        }
    }
}

