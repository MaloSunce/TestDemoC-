namespace LibraryAPI.Classes;

public class Author
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public DateTime? dateOfBirth { get; set; }
    public List<Book> Works { get; set; } = [];
}