using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Classes;
using NUnit.Framework;

namespace LibraryAPI.Tests.Classes;

public class BookTest
{
    private Book availableTestBook;
    private Book unavailableTestBook;
    private Book nonBorrowedBook;

    [SetUp]
    public void Setup()
    {
        availableTestBook = new Book()
        {
            BookId = 11,
            Title = "The Stranger",
            Author = "Albert Camus",
            Publisher = "Vintage",
            PublicationDate = new DateTime(2020),
            Language = "English",
            
            Available = true,
            Lender = null,
        };
        unavailableTestBook = new Book()
        {
            BookId = 22,
            Title = "The Fall",
            Author = "Albert Camus",
            Publisher = "Penguin Classics",
            
            Available = false,
        };
        nonBorrowedBook = new Book()
        {
            BookId = 44,
            Title = "The Plague",
            Author = "Albert Camus",
            Publisher = "Penguin Classics",
            Language = "French",
            
            Available = true,
            Lender = null,
        };
    }

    [Test]
    public void TestGetBookValues()
    {
        List<string> values = [];
        
        values.Add(availableTestBook.Title);
        values.Add(availableTestBook.Author!);
        values.Add(availableTestBook.Publisher!);
        values.Add(availableTestBook.Language!);
        values.Add(availableTestBook.PublicationDate.ToString()!);
        values.Add(unavailableTestBook.Lender!.FirstName);

        // Look for empty strings
        var emptyItem = values.FirstOrDefault(item => item == "");

        if (emptyItem != null)
        {
            Assert.Fail("Found empty string");
        }

        Assert.Pass();
    }
}