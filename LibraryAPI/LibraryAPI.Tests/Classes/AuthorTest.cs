using System;
using LibraryAPI.Classes;
using NUnit.Framework;

namespace LibraryAPI.Tests.Classes;

[TestFixture]
[TestOf(typeof(Author))]
public class AuthorTest
{
    
    private Author testAuthor;
    private Book testBook;

    [SetUp]
    public void Setup()
    {
        testBook = new Book()
        {
            BookId = 0,
            Title = "testBook 0",
            Available = true
        };
        testAuthor = new Author()
        {
            FirstName = "Albert",
            LastName = "Camus",
            dateOfBirth =  new DateTime(1913, 11, 7),
            Works = [testBook, testBook, testBook],
        };
    }
    
    [Test]
    public void TestGetAuthorWorks()
    {
        var works = testAuthor.Works;

        if (works.Count != 3)
        {
            Assert.Fail($"Expected 3 works, got {works.Count}");
        }
        
        Assert.Pass();
    }
    
    [Test]
    public void TestGetAuthorDoB()
    {
        var dateOfBirth = testAuthor.dateOfBirth;
        var expected = new DateTime(1913, 11, 7);

        if (dateOfBirth != expected)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }
}