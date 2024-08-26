using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICoreTasks.DTOs;
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
        [HttpPost]
        public IActionResult AddProduct([FromForm] UsersRequests users)
        {

            var user = new User
            {
                Username = users.Username,
                Email= users.Email,
                Password = users.Password,      
             
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok();
            
        }

        [HttpPut("{id}")]
        public IActionResult updateProduct(int id, [FromForm] UsersRequests user)
        {
            var u = _db.Users.Where(p => p.UserId == id).FirstOrDefault();

            u.Username = user.Username;
            u.Email = user.Email;
            u.Password = user.Password;

            _db.Users.Update(u);
            _db.SaveChanges();
            return Ok();
        }
    }
}

