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

        // POST api/library/users (example: create a new user)
        [HttpPost("users")]
        public IActionResult AddUser([FromBody] User newUser)
        {
            library.AllUsers.Add(newUser);
            return CreatedAtAction(nameof(GetAllUsers), new { id = newUser.UserId }, newUser);
        }
    }
}