using LibraryAPI.Classes;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController(Library library) : ControllerBase
    {
        
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            return Ok(library.AllUsers);
        }
        
        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            return Ok(library.AllBooks);
        }

        // POST api/library/users 
        [HttpPost("users")]
        public IActionResult AddUser([FromBody] string username)
        {
            // Create new user
            library.NewUser(username);

            // Return username and id of new user
            return Ok(new { UserId = library.AllUsers[^1].UserId, UserName = library.AllUsers[^1].FirstName });
        }
    }
}