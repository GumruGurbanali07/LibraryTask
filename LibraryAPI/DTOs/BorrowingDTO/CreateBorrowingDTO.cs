namespace LibraryAPI.DTOs.BorrowingDTO
{
    public class CreateBorrowingDTO
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int UserId { get; set; } 
        public int BookId { get; set; }
    }
}
