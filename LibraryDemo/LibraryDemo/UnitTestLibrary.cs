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
    public void TestAddBookValid()
    {
        testLibrary.AddBook(title: "...", author: "...", publisher: null, publicationDate: null);
        
        Assert.Pass();
    }
}