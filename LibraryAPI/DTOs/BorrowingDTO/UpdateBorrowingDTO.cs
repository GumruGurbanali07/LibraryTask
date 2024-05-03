namespace LibraryAPI.DTOs.BorrowingDTO
{
    public class UpdateBorrowingDTO
    {
        public int BorrowingId { get; set; }    
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
