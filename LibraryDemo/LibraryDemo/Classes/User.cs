namespace LibraryDemo.Classes;

public class User(string name, int id)
{
    public readonly int UserId = id;
    public string FirstName = name;
    
    public List<Book> BorrowedBooks = new List<Book>();
}