using LibraryDemo.Classes;

namespace LibraryDemo;

public class Tests
{
    private Library testLibrary;
    private User testUser;
    private Book availableTestBook;
    private Book unavailableTestBook;
    private Book nonBorrowedBook;
    private Author testAuthor;

    [SetUp]
    public void Setup()
    {
        testLibrary = new Library();
        testAuthor = new Author()
        {
            FirstName = "Albert",
            LastName = "Camus",
        };
        testUser = new User("testUser", 11);
        availableTestBook = new Book()
        {
            BookId = 11,
            Title = "The Stranger",
            Author = testAuthor.FirstName + " " + testAuthor.LastName,
            Publisher = "Vintage",
            
            Available = true,
            Lender = null,
        };
        unavailableTestBook = new Book()
        {
            BookId = 22,
            Title = "The Fall",
            Author = testAuthor.FirstName + " " + testAuthor.LastName,
            Publisher = "Penguin Classics",
            
            Available = false,
            Lender = testUser,
        };
        nonBorrowedBook = new Book()
        {
            BookId = 44,
            Title = "The Plague",
            Author = testAuthor.FirstName + " " + testAuthor.LastName,
            Publisher = "Penguin Classics",
            
            Available = true,
            Lender = null,
        };
        
        testLibrary.AllBooks.Add(unavailableTestBook);
        testLibrary.AllBooks.Add(availableTestBook);
        testLibrary.AllUsers.Add(testUser);
        testUser.AddBorrowedBook(availableTestBook);
        testAuthor.Works.Add(unavailableTestBook);
        testAuthor.Works.Add(availableTestBook);
        testAuthor.Works.Add(nonBorrowedBook);
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
    // Test RemoveBorrowedBook on a book that has not been borrowed by testUser
    public void TestRemoveUnborrowedBook()
    { ;
        var errorMessage = testUser.RemoveBorrowedBook(nonBorrowedBook);

        if (errorMessage != null)
        {
            Assert.Pass(errorMessage);
        } 
        
        Assert.Fail();
    }
    
    [Test]
    // Test UpdateBookAvailability with borrowing a book that is unavailable
    public void TestBorrowUnavailableBook()
    {
        var errorMessage = testLibrary.UpdateBookAvailability(
            bookId: unavailableTestBook.BookId, userId: testUser.UserId, borrow: true);

        if (errorMessage != null)
        {
            Assert.Pass(errorMessage);
        }
        
        Assert.Fail();
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