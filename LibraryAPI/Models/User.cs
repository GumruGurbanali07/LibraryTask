using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LibraryAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Book> Books { get; set; }
        public List<Borrowing> Borrowings { get; set; }
    }
}
