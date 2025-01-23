using LibraryDemo.Classes;

namespace LibraryDemo;

public class Tests
{
    private Library testLibrary;
    private User testUser;
    private Book availableTestBook;
    private Book unavailableTestBook;

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
        unavailableTestBook = new Book()
        {
            BookId = 22,
            Title = "Metamorphosis",
            Author = "Franz Kafka",
            Publisher = "Penguin Books",
            
            Available = false,
            Lender = testUser,
        };
        
        testLibrary.AllBooks.Add(unavailableTestBook);
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
    
    [Test]
    public void TestBorrowUnavailableBook()
    {
        var errorMessage = testLibrary.UpdateBookAvailability(
            bookId: unavailableTestBook.BookId, userId: testUser.UserId, borrow: true);

        if (errorMessage == null)
        {
            Assert.Fail();
        }
        
        Assert.Pass();
    }
}