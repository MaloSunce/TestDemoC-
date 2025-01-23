using LibraryAPI.Classes;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController(Library library) : ControllerBase
    {
        
        [HttpGet("all_users")]
        public IActionResult GetAllUsers()
        {
            return Ok(library.AllUsers);
        }
        
        [HttpGet("all_books")]
        public IActionResult GetAllBooks()
        {
            return Ok(library.AllBooks);
        }

        // POST api/library/new_user 
        [HttpPost("new_user")]
        public IActionResult AddUser([FromBody] string username)
        {
            // Create new user
            library.NewUser(username);

            // Return username and id of new user
            return Ok(new { UserId = library.AllUsers[^1].UserId, UserName = library.AllUsers[^1].FirstName });
        }
        
        // POST api/library/new_book 
        [HttpPost("new_book")]
        public IActionResult AddBook(
            [FromForm] string title,
            [FromForm] string author,
            [FromForm] string publisher,
            [FromForm] DateTime? publicationDate,
            [FromForm] string language)
        {
     
            library.AddBook(
                title: title, 
                author: author, 
                publisher: publisher, 
                publicationDate: publicationDate,
                language: language
                );
            return Ok($"Added {library.AllBooks[^1].Title} to library.");
        }
    }
}