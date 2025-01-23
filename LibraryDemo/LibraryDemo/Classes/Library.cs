﻿namespace LibraryDemo.Classes;

public class Library
{
    public List<User> AllUsers { get; set; } = new List<User>();
    public List<Book> AllBooks { get; set; } = new List<Book>();

    public void AddBook(string title, string author, string publisher, DateTime publicationDate)
    {
        // Find unused bookID
        var sortedBooks = AllBooks.OrderBy(book => book.BookId).ToList();
        var lastId = sortedBooks[^1].BookId;

        // Create new Book instance and push to AllBooks
        var newBook = new Book()
        {
            BookId = lastId + 1,
            Title = title,
            Author = author,
            Publisher = publisher,
            PublicationDate = publicationDate,
            Available = true,
            Lender = null,
        };
        AllBooks.Add(newBook);
    }
    
    public void RemoveBook(string title) {}
    
    public void FindBook(string title) {}
    
    public void BorrowBook(string title, int UserId) {}
    
    public void ReturnBook(string title) {}

    public void NewUser(string username)
    {
        // Sort all users by UserId
        var sortedUsers = AllUsers.OrderBy(user => user.UserId).ToList();

        // Get largest Id
        var lastId = sortedUsers[^1].UserId;
        
        // Create new user and push to list
        var newUser = new User(username, lastId + 1);
        AllUsers.Add(newUser);
    }

}