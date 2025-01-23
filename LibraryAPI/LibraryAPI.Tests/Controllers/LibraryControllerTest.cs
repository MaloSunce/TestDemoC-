using System.Collections.Generic;
using LibraryAPI.Classes;
using LibraryAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LibraryAPI.Tests.Controllers;

public class LibraryControllerTest
{
    private LibraryController _controller;
    private Library _mockLibrary;

    [SetUp]
    public void Setup()
    {
        _mockLibrary = new Library();
        _mockLibrary.AllUsers.Add(new User("testUser1", 1));
        _mockLibrary.AllUsers.Add(new User("testUser2", 2));
        _mockLibrary.AllBooks.Add(new Book()
        {      
            BookId = 1,
            Title = "testBook1",
            Available = true
            
        });
        _mockLibrary.AllBooks.Add(new Book()
        {
            BookId = 2,
            Title = "testBook2",
            Available = false
        });

        _controller = new LibraryController(_mockLibrary);
    }

    [Test]
    public void TestGetAllUsers()
    {
        var result = _controller.GetAllUsers();
        //Assert.IsInstanceOf<OkObjectResult>(result); 
        Assert.IsNotNull(result);

        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);

        var users = okResult.Value as List<User>;
        Assert.IsNotNull(users);

        Assert.AreEqual(2, users.Count);

        Assert.AreEqual("testUser1", users[0].FirstName);
        Assert.AreEqual(1, users[0].UserId);

        Assert.AreEqual("testUser2", users[1].FirstName); 
        Assert.AreEqual(2, users[1].UserId);
    }
    
    [Test]
    public void TestGetAllBooks()
    {
        var result = _controller.GetAllBooks();
        //Assert.IsInstanceOf<OkObjectResult>(result); 
        Assert.IsNotNull(result);

        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);

        var books = okResult.Value as List<Book>;
        Assert.IsNotNull(books);

        Assert.AreEqual(2, books.Count);

        Assert.AreEqual("testBook1", books[0].Title);
        Assert.AreEqual(1, books[0].BookId);

        Assert.AreEqual("testBook2", books[1].Title); 
        Assert.AreEqual(2, books[1].BookId);
    }
    
    [Test]
    public void TestNewUser()
    {
        string username = "testUser";
        
        var result = _controller.AddUser(username);
        Assert.IsNotNull(result);

        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        
        var returnedUser = okResult.Value as dynamic;
        Assert.IsNotNull(returnedUser);
        Assert.AreEqual(username, returnedUser.UserName);
        Assert.AreEqual(3, returnedUser.UserId);
        
        Assert.AreEqual(3, _mockLibrary.AllUsers.Count);
        Assert.AreEqual(username, _mockLibrary.AllUsers[^1].FirstName);
    }
}