using LibraryAPI.DataBase.AppDbContext;
using LibraryAPI.DTOs.GenreDTO;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenreController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateGenre(CreateGenreDTO createGenreDTO)
        {
            Genre genre = new Genre()
            {
                Name = createGenreDTO.Name
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return Ok("Adding is okei");
        }

        [HttpGet]
        public IActionResult GetGenreList()
        {
            var values = _context.Genres.ToList();
            return Ok(values);
        }
        [HttpGet("{genreId}")]
        public IActionResult GetGenre(int genreId)
        {
            var values = _context.Genres.Find(genreId);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateGenre(UpdateGenreDTO updateGenreDTO)
        {
            Genre genre = new Genre()
            {
                 GenreId = updateGenreDTO.GenreId,
                 Name = updateGenreDTO.Name
            };
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return Ok("Updating is okey");
        }

        [HttpDelete]
        public IActionResult DeleteGenre(int genreId)
        {
            var values = _context.Genres.Find(genreId);
            _context.Genres.Remove(values);
            _context.SaveChanges();
            return Ok("Removing is okey");
        }
    }
}
