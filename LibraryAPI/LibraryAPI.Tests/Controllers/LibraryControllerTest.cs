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
}