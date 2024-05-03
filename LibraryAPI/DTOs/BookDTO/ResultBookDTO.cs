namespace LibraryAPI.DTOs.BookDTO
{
    public class ResultBookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string GenreName { get; set; }
        public int GenreId { get; set;}

    }
}
