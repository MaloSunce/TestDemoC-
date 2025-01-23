using System.Runtime.InteropServices.JavaScript;

namespace LibraryDemo.Classes;

public class User(string name, int id, List<Book> borrowedBooks)
{
    public readonly int UserId = id;
    public string FirstName = name;

    private List<Book> BorrowedBooks = borrowedBooks;

    public string? AddBorrowedBook(Book book)
    {
        // Check if book already exists in the list
        if (BorrowedBooks.All(b => b.BookId != book.BookId))
        {
            try
            {
                // Add book to list if it does not already exist in the collection
                if (BorrowedBooks.Count >= Consts.MaxBorrowedBooks)
                {
                    BorrowedBooks.Add(book);
                }
                else
                { 
                    return $"User {UserId} has already borrowed the maximum number of books!"; 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else // Return error string if the book was already in the list
        {
            return $"The book with id {book.BookId} is already borrowed by user {UserId}.";
        }

        return null;
    }

    public string? RemoveBorrowedBook(Book book)
    {
        // Try to find the book in BorrowedBooks
        if (BorrowedBooks.All(b => b.BookId == book.BookId))
        {
            try
            {
                BorrowedBooks.Remove(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else // Return error string if the book was not found
        {
            return $"Failed to find book with id {book.BookId} in user {UserId}.";
        }

        return null;
    }
}