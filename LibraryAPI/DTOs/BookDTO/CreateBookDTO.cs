namespace LibraryAPI.DTOs.BookDTO
{
    public class CreateBookDTO
    {
        public int AuthorId { get; set; }
        public int UserId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
