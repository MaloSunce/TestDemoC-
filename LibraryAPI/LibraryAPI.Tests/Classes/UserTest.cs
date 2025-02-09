﻿using LibraryAPI.Classes;
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
    // Test User.AddBorrowedBook twice on the same user with the same book
    public void TestBorrowAvailableBook()
    {
        var errorMessage = testUser.BorrowBook(availableBook);

        if (errorMessage == null)
        {
            Assert.Pass();
        } 
        
        Assert.Fail(errorMessage);
    }

    [Test]
    // Test AddBorrowedBook twice on the same user with the same book
    public void TestReBorrowBook()
    {
        testUser.BorrowBook(availableBook);
        var errorMessage = testUser.BorrowBook(availableBook);

        if (errorMessage != null)
        {
            Assert.Pass(errorMessage);
        } 
        
        Assert.Fail();
    }
    
    [Test]
    // Test RemoveBorrowedBook on a book that has not been borrowed by testUser
    public void TestRemoveUnborrowedBook()
    { ;
        var errorMessage = testUser.RemoveBorrowedBook(nonBorrowedBook);

        if (errorMessage == null)
        {
            Assert.Fail();
        } 
        
        Assert.Pass(errorMessage);
    }
    
    [Test]
    // Test RemoveBorrowedBook on a book that has been added to testUser
    public void TestRemoveBorrowedBook()
    {
        testUser.BorrowBook(availableBook);
        var errorMessage = testUser.RemoveBorrowedBook(availableBook);

        if (errorMessage == null)
        {
            Assert.Pass();
        } 
        
        Assert.Fail(errorMessage);
    }
}