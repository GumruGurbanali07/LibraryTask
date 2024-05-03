namespace LibraryAPI.DTOs.BorrowingDTO
{
    public class ResultBorrowingDTO
    {
        public int BorrowingId { get; set; }    
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public int BookId { get; set; }
    }
}
