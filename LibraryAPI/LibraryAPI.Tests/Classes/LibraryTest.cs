using System;
using LibraryAPI.Classes;
using NUnit.Framework;

namespace LibraryAPI.Tests.Classes;

public class LibraryTest
{
    private Library testLibrary;
    private User testUser;
    private Book availableTestBook;
    private Book unavailableTestBook;
    private Book nonBorrowedTestBook;
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
            BookId = 0,
            Title = "testBook 0",
            Available = true
        };
        unavailableTestBook= new Book()
        {
            BookId = 1,
            Title = "testBook 1",
            Available = false
        };
        nonBorrowedTestBook = new Book()
        {
            BookId = 2,
            Title = "testBook 3",
            
            Available = true,
            Lender = null,
        };
        
        testLibrary.AllBooks.Add(unavailableTestBook);
        testLibrary.AllBooks.Add(availableTestBook);
        testLibrary.AllUsers.Add(testUser);
        testUser.BorrowBook(availableTestBook);

        testAuthor.Works = [unavailableTestBook, availableTestBook, nonBorrowedTestBook];
    }

    [Test]
    // Tests the AddBook method with a valid book
    public void TestAddBook()
    {
        Exception exception = null!;
        try{
            testLibrary.AddBook(title: "testTitle1", author: "testAuthor1", publisher: null, publicationDate: null, language: null);
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
    // Test the NewUser method with a valid user
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
            Assert.Fail(exception.Message);
        }

        if (testLibrary.AllUsers[^1].FirstName != "testUser")
        {
            Assert.Fail("User was not sucessfully added to AllUsers.");
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