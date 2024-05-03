using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Borrowing
    {
        [Key]
       public int BorrowingId { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }

       
        public int BookId { get; set; }
        public Book Book { get; set; } 

        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; } 
    }
}
