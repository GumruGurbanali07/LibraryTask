using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

       
        public int AuthorId { get; set; }
        public Author Author { get; set; } 

        public int UserId { get; set; }
        public User User { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; } 

        
        public List<Borrowing> Borrowings { get; set; }
    }
}
