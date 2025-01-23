namespace LibraryDemo.Classes;

public class Book
{
    public required int BookId { get; set; }
    
    public required string Title { get; set; }
    public string? Author { get; set; }
    public string? Publisher { get; set; }
    public DateTime? PublicationDate { get; set; }
    
    public required bool Available { get; set; }

    public User? Lender { get; set; }
}