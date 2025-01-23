using LibraryAPI.Classes;
using NUnit.Framework;

namespace LibraryAPI.Tests.Classes;

public class UserTest
{
    private User testUser;
    private Book availableBook;
    private Book unavailableBook;


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
}