using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTasks.Models;

namespace WebAPICoreTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
            MyDbContext _db;

            public UsersController(MyDbContext db)
            {
                _db = db;
            }

            [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _db.GetAllUsers();
            if (users == null)
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        // 2.
        [HttpGet("getUserById/{id:int}")]
        public IActionResult GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }

            var user = _db.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // 3. 
        [HttpGet("getUserByName/{name}")]
        public IActionResult GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be null or empty.");
            }

            var user = _db.GetUserByName(name);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // 4. 
        [HttpDelete("deleteUser/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }

            var success = _db.DeleteUser(id);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return NoContent();
        }
    }
}
}
