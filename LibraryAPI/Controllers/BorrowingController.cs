using LibraryAPI.DataBase.AppDbContext;
using LibraryAPI.DTOs.BorrowingDTO;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BorrowingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateBorrowing(CreateBorrowingDTO createBorrowingDTO)
        {

            Borrowing borrowing = new Borrowing()
            {
                BorrowedDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                ReturnedDate = createBorrowingDTO.ReturnedDate,
                UserId = createBorrowingDTO.UserId,
                BookId = createBorrowingDTO.BookId
            };
            _context.Borrowings.Add(borrowing);
            _context.SaveChanges();
            return Ok("Adding is okei");
        }

        [HttpGet]
        public IActionResult GetBorrowingList()
        {
            var values = _context.Borrowings.Include(x => x.User).Include(y => y.Book).Select(z => new ResultBorrowingDTO()
            {
                BorrowingId = z.BorrowingId,
                BorrowedDate = z.BorrowedDate,
                ReturnedDate = z.ReturnedDate,
                UserName = z.User.Name,
                UserId = z.UserId,
                BookName = z.Book.Title,
                BookId = z.BookId
            }).ToList();
            return Ok(values);
        }
        [HttpGet("{borrowingId}")]
        public IActionResult GetBorrowing(int borrowingId)
        {
            var values = _context.Borrowings.Include(x => x.User).Include(y => y.Book).Select(z => new ResultBorrowingDTO()
            {
                BorrowingId = z.BorrowingId,
                BorrowedDate = z.BorrowedDate,
                ReturnedDate = z.ReturnedDate,
                UserName = z.User.Name,
                UserId = z.UserId,
                BookName = z.Book.Title,
                BookId = z.BookId
            }).FirstOrDefault(x => x.BorrowingId == borrowingId);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateBorrowing(UpdateBorrowingDTO updateBorrowingDTO)
        {
            Borrowing borrowing = new Borrowing()
            {
                BorrowingId=updateBorrowingDTO.BorrowingId,
                BorrowedDate=DateTime.Now,
                ReturnedDate=DateTime.Now,
                UserId = updateBorrowingDTO.UserId,
                BookId=updateBorrowingDTO.BookId
            };
            _context.Borrowings.Update(borrowing);
            _context.SaveChanges();
            return Ok("Updating is okey");
        }
        [HttpDelete]
        public IActionResult DeleteBorrowing(int borrowingId)
        {
            var values = _context.Borrowings.Find(borrowingId);
            _context.Borrowings.Remove(values);
            _context.SaveChanges();
            return Ok("Removing is okei");
        }
    }
}
