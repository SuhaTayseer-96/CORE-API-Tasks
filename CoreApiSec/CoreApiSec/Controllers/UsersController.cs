using CoreApiSec.DTOs;
using CoreApiSec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiSec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UsersController(MyDbContext db)
        {
            _db = db;
        }

        [HttpPost("register")] // pot because it will save in sql
        public async Task<ActionResult<User>>Register(UsersDTO usersDTO)
         
        { 
            byte[] passwordHash, passwordSalt;
            PasswordHasher.CreatePasswordHash(usersDTO.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Username = usersDTO.Username,
                Email = usersDTO.Email,
                Password = usersDTO.Password,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UsersDTO model)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
            if (user == null || !PasswordHasher.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }
            // Generate a token or return a success response
            return Ok("User logged in successfully");
        }
    }
}
