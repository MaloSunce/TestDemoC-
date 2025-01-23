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
        testUser.AddBorrowedBook(availableTestBook);
    }

    [Test]
    public void TestAddBook()
    {
        Exception exception = null!;
        try{
            testLibrary.AddBook(title: "testTitle1", author: "testAuthor1", publisher: null, publicationDate: null);
        }
        catch (Exception ex){
            exception = ex;
        }

        if (exception != null)
        {
            Assert.Fail();
        }
        
        Assert.Pass();
    }
    
    [Test]
    public void TestNewUser()
    {
        Exception exception = null!;
        try{
            testLibrary.NewUser("testUser");
        }
        catch (Exception ex){
            exception = ex;
        }

        if (exception != null)
        {
            Assert.Fail();
        }
        
        Assert.Pass();
    }


    [Test]
    // Test UpdateBookAvailability() with borrowing a book that is available
    public void TestBorrowAvailableBook()
    {
        var errorMessage = testLibrary.UpdateBookAvailability(
            bookId: availableTestBook.BookId, userId: testUser.UserId, borrow: true);

        if (errorMessage != null)
        {
            Assert.Fail(errorMessage);
        } 
        else if (availableTestBook.Available == true) // Check that book availability has been updated correctly
        {
            Assert.Fail("availableTestBook.Available == true");
        }
        
        Assert.Pass();
    }
    
    [Test]
    // Test AddBorrowedBook twice on the same user with the same book
    public void TestReBorrowBook()
    {
        testUser.AddBorrowedBook(unavailableTestBook);
        var errorMessage = testUser.AddBorrowedBook(unavailableTestBook);

        if (errorMessage != null)
        {
            Assert.Pass(errorMessage);
        } 
        
        Assert.Pass();
    }
    
    [Test]
    // Test UpdateBookAvailability with borrowing a book that is unavailable
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
    
    
    [Test]
    // Test UpdateBookAvailability() with returning a book that was borrowed by testUser
    public void TestReturnValidBook()
    {
        var errorMessage = testLibrary.UpdateBookAvailability(
            bookId: unavailableTestBook.BookId, userId: testUser.UserId, borrow: false);

        if (errorMessage != null)
        {
            Assert.Fail(errorMessage);
        }   
        else if (availableTestBook.Available != true)
        {
            Assert.Fail("availableTestBook.Available != true");
        }
        
        Assert.Pass();
    }
    
}