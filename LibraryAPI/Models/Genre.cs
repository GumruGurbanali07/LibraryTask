using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
