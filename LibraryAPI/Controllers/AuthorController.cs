using LibraryAPI.DataBase.AppDbContext;
using LibraryAPI.DTOs.AuthorDtos;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AuthorList()
        {
            var values = _context.Authors.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAuthor(CreateAuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                Name = authorDTO.Name,
                Biography = authorDTO.Biography,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            return Ok("Addition is successfull");

        }
        [HttpPut]
        public IActionResult UpdateAuthor(UpdateAuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                AuthorId = authorDTO.AuthorId,
                Name = authorDTO.Name,
                Biography = authorDTO.Biography,
            };
            _context.Authors.Update(author);
            _context.SaveChanges();
            return Ok("Update is successfull");
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int authorId)
        {
            var values = _context.Authors.Find(authorId);
            _context.Remove(values);
            _context.SaveChanges();
            return Ok("Removing is successfull");
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(int authorId)
        {
            var values = _context.Authors.Find(authorId);
            return Ok(values);
        }
    }
}
