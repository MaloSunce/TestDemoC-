﻿namespace LibraryAPI.Classes;

public class Library
{
    public List<User> AllUsers { get; } = [];
    public List<Book> AllBooks { get; } = [];

    public void AddBook(string title, string author, string? publisher, DateTime? publicationDate, string? language)
    {
        try
        {
            // Find unused bookID
            var lastId = 0;
            if (AllBooks.Count > 0)
            {
                var sortedBooks = AllBooks.OrderBy(book => book.BookId).ToList();
                lastId =  sortedBooks[^1].BookId;
            }
            
            // Create new Book instance and push to AllBooks
            var newBook = new Book()
            {
                BookId = lastId + 1,
                Title = title,
                Author = author,
                Publisher = publisher,
                PublicationDate = publicationDate,
                Language = language,
                Available = true,
                Lender = null,
            };
            AllBooks.Add(newBook);
        } 
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void RemoveBook(string title)
    {
    }

    public string? UpdateBookAvailability(int bookId, int userId, bool borrow)
    {
        try
        {
            var book = AllBooks.FirstOrDefault(book => book.BookId == bookId);
            var user = AllUsers.FirstOrDefault(user => user.UserId == userId);
            
            if (book == null || user == null)
                return book == null ? $"Failed to find book with id {bookId}." : $"Failed to user with id {userId}.";

            if (book.Available != borrow) 
                return book.Available == false ? $"This book has already been borrowed." : $"This book has not been borrowed.";
            
            book.Lender = user;
            book.Available = !borrow;
            
            if (borrow)
            {
                user.BorrowBook(book);
            }
            else
            {
                user.RemoveBorrowedBook(book);
            }
                
            return null;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void NewUser(string username)
    {
        try
        {
            // Find a valid userId
            var lastId = 0;
            if (AllBooks.Count > 0)
            {
                var sortedUsers = AllUsers.OrderBy(user => user.UserId).ToList();
                lastId =  sortedUsers[^1].UserId;
            }

            // Create new user and push to list
            var newUser = new User(username, lastId + 1);
            AllUsers.Add(newUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}