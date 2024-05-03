using LibraryAPI.DataBase.AppDbContext;
using LibraryAPI.DTOs.UserDTO;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserDTO createUserDTO)
        {
            User user = new User()
            {
                Name = createUserDTO.Name,
                Email = createUserDTO.Email
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Creating is okey");
        }
        [HttpGet]
        public IActionResult GetUserList()
        {
            var values = _context.Users.ToList();
            return Ok(values);
        }
        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var values = _context.Users.Find(userId);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO updateUserDTO)
        {
            User user = new User()
            {
                UserId=updateUserDTO.UserId,
                Name= updateUserDTO.Name,
                Email= updateUserDTO.Email
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Updating is okey");
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            var values= _context.Users.Find(userId);
            _context.Users.Remove(values);
            _context.SaveChanges();
            return Ok("Removing is okey");
        }

    }
}
