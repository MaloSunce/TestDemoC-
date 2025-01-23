namespace LibraryDemo.Classes;

public class Library
{
    public List<User> AllUsers { get; } = [];
    public List<Book> AllBooks { get; } = [];

    public void AddBook(string title, string author, string? publisher, DateTime? publicationDate)
    {
        try
        {
            // Find unused bookID
            var lastId = 0;
            if (AllBooks.Count > 0)
            {
                var sortedBooks = AllBooks.OrderBy(book => book.BookId).ToList();
                lastId =  sortedBooks[^1].BookId;
            }
            
            // Create new Book instance and push to AllBooks
            var newBook = new Book()
            {
                BookId = lastId + 1,
                Title = title,
                Author = author,
                Publisher = publisher,
                PublicationDate = publicationDate,
                Available = true,
                Lender = null,
            };
            AllBooks.Add(newBook);
        } 
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void RemoveBook(string title)
    {
    }

    public void UpdateBookAvailability(int bookId, User? user, bool borrow)
    {
        try
        {
            var book = AllBooks.FirstOrDefault(book => book.BookId == bookId);

            if (book != null)
            {
                book.Lender = user;
                book.Available = borrow;
            }

            else
            {
                throw new Exception($"Failed to find the book with id {bookId}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void NewUser(string username)
    {
        try
        {
            // Sort all users by UserId
            var sortedUsers = AllUsers.OrderBy(user => user.UserId).ToList();

            // Get largest Id
            var lastId = sortedUsers[^1].UserId;

            // Create new user and push to list
            var newUser = new User(username, lastId + 1);
            AllUsers.Add(newUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}