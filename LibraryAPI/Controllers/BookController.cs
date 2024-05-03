using LibraryAPI.DataBase.AppDbContext;
using LibraryAPI.DTOs.BookDTO;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateBook(CreateBookDTO createBookDTO)
        {
            Book book = new Book()
            {
                Title = createBookDTO.Title,
                ISBN = createBookDTO.ISBN,
                PublicationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                AuthorId = createBookDTO.AuthorId,
                UserId = createBookDTO.UserId,
                GenreId = createBookDTO.GenreId
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok("Adding is succesfull");

        }
        [HttpGet]
        public IActionResult GetBookList()
        {

            var values = _context.Books.Include(x => x.Author).Include(y => y.Genre).Include(z => z.User).Select(f => new ResultBookDTO()
            {
                BookId = f.BookId,
                Title = f.Title,
                ISBN = f.ISBN,
                PublicationDate = f.PublicationDate,
                AuthorId = f.AuthorId,
                AuthorName = f.Author.Name,
                UserId = f.UserId,
                UserName = f.User.Name,
                GenreId = f.GenreId,
                GenreName = f.Genre.Name

            }).ToList();
            return Ok(values);
        }
        [HttpGet("{bookId}")]
        public IActionResult GetBook(int bookId)
        {
            var values = _context.Books.Include(x => x.Author).Include(y => y.Genre).Include(z => z.User).Select(f => new ResultBookDTO()
            {
                BookId = f.BookId,
                Title = f.Title,
                ISBN = f.ISBN,
                PublicationDate = f.PublicationDate,
                AuthorId = f.AuthorId,
                AuthorName = f.Author.Name,
                UserId = f.UserId,
                UserName = f.User.Name,
                GenreId = f.GenreId,
                GenreName = f.Genre.Name

            }).FirstOrDefault(x => x.BookId == bookId);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateBook(UpdateBookDTO updateBookDTO)
        {
            Book book = new Book()
            {
                BookId=updateBookDTO.BookId,
                Title = updateBookDTO.Title,
                ISBN = updateBookDTO.ISBN,
                PublicationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                AuthorId = updateBookDTO.AuthorId,
                UserId = updateBookDTO.UserId,
                GenreId = updateBookDTO.GenreId

            };
            _context.Books.Update(book);
            _context.SaveChanges();
            return Ok("Updating is successfull");
        }

        [HttpDelete]
        public IActionResult DeleteBook(int bookId)
        {
            var values = _context.Books.Find(bookId);
            _context.Books.Remove(values);
            _context.SaveChanges();
            return Ok("Removing is okey");
        }


    }
}
