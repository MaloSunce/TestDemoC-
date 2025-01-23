namespace LibraryDemo.Classes;

public class Library
{
    
    public List<User> AllUsers { get; set; }
    
    public void AddBook(Book book) {}
    
    public void RemoveBook(string title) {}
    
    public void FindBook(string title) {}
    
    public void BorrowBook(string title, int UserId) {}
    
    public void ReturnBook(string title) {}

    public void NewUser(string username)
    {
        // Sort all users by UserId
        var sortedUsers = AllUsers.OrderBy(user => user.UserId).ToList();

        // Get largest Id
        var lastId = sortedUsers[^1].UserId;
        
        // Create new user and push to list
        var newUser = new User(username, lastId + 1);
        AllUsers.Add(newUser);
    }

}