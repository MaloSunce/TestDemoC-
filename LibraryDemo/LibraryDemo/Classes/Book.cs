namespace LibraryDemo.Classes;

public class Book
{
    public required int BookId { get; set; }
    
    public required string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public string PublicationDate { get; set; }
    
    public bool Available { get; set; }

    private User Lender { get; set; }
}