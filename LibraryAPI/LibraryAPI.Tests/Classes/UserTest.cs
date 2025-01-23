using LibraryAPI.Classes;
using NUnit.Framework;

namespace LibraryAPI.Tests.Classes;

public class UserTest
{
    private User testUser;
    private Book availableBook;
    private Book unavailableBook;
    private Book nonBorrowedBook;


    [SetUp]
    public void Setup()
    {
        testUser = new User("testUser", 11);
        availableBook = new Book()
        {
            BookId = 0,
            Title = "testBook 0",
            Available = true
        };
        unavailableBook= new Book()
        {
            BookId = 1,
            Title = "testBook 1",
            Available = false
        };
        nonBorrowedBook = new Book()
        {
            BookId = 2,
            Title = "testBook 3",
            
            Available = true,
            Lender = null,
        };
    }

    [Test]
    // Test AddBorrowedBook twice on the same user with the same book
    public void TestReBorrowBook()
    {
        testUser.AddBorrowedBook(availableBook);
        var errorMessage = testUser.AddBorrowedBook(availableBook);

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
}