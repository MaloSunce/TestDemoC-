using System;
using LibraryAPI.Classes;
using NUnit.Framework;

namespace LibraryAPI.Tests.Classes;

[TestFixture]
[TestOf(typeof(Author))]
public class AuthorTest
{
    
    private Author testAuthor;

    [SetUp]
    public void Setup()
    {
        testAuthor = new Author()
        {
            FirstName = "Albert",
            LastName = "Camus",
            dateOfBirth =  new DateTime(1913, 11, 7),
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


}