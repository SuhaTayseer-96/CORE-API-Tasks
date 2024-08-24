using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTasks.Models;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(MyDbContext db) : ControllerBase
    {
        MyDbContext _db = db;

        //First : getAllCategories
        [Route("categories")]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _db.GetAllCategories();
            return Ok(categories);
        }

        //- Second : GetCategoryById    // minvalue of id =5
        [Route("categories/{id}")]
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        { 
        if (id < 5)
            {
                return BadRequest("Must greater than 5");
            }
        return Ok();
        }

        //- third : Get CategoryByName
        [Route("categories/name/{name}")]
        [HttpGet]
        public IActionResult GetCategoryByName(String name)
        {
            var categories = _db.GetCategoryByName(name);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        //- Fourth : DeleteCategory
        [Route("categories/delete/{id}")]
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            if (id < 5)
            {
                return BadRequest("Must greater than 5");
            }
            var s = _db.DeleteCategory(id);
            if (!s) 
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
