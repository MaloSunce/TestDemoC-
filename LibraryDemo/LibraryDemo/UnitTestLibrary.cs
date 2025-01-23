using LibraryDemo.Classes;

namespace LibraryDemo;

public class Tests
{
    private Library testLibrary;

    [SetUp]
    public void Setup()
    {
        testLibrary = new Library();
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

    /*
    [Test]
    public void TestUpdateBookAvailabilityValidId()
    {
        
        testLibrary.UpdateBookAvailability(0, ...)
        
    }*/
}