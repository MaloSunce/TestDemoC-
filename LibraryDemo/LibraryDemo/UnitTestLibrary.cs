using LibraryDemo.Classes;

namespace LibraryDemo;

public class Tests
{
    private Library testLibrary;
    private User testUser;
    private Book availableTestBook;

    [SetUp]
    public void Setup()
    {
        testLibrary = new Library();
        testUser = new User("testUser", 11);
        availableTestBook = new Book()
        {
            BookId = 11,
            Title = "The Stranger",
            Author = "Albert Camus",
            Publisher = "Vintage",
            
            Available = true,
            Lender = null,
        };
        
        testLibrary.AllBooks.Add(availableTestBook);
        testLibrary.AllUsers.Add(testUser);
    }

    [Test]
    public void TestAddBook()
    {
        testLibrary.AddBook(title: "testTitle1", author: "testAuthor1", publisher: null, publicationDate: null);
        
        Assert.Pass();
    }
    
    [Test]
    public void TestNewUser()
    {
        testLibrary.NewUser("testUser");
        
        Assert.Pass();
    }


    [Test]
    public void TestBorrowAvailableBook()
    {
        var errorMessage = testLibrary.UpdateBookAvailability(
            bookId: availableTestBook.BookId, userId: testUser.UserId, borrow: true);

        if (errorMessage != null)
        {
            Assert.Fail(errorMessage);
        }
        
        Assert.Pass();
    }
}