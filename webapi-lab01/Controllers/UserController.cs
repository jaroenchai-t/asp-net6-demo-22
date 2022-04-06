using Microsoft.AspNetCore.Mvc;
using webapi_lab01.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi_lab01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext _context;
        public UserController(MyDBContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Users.ToList());
        }

        // GET api/<UserController>/lex
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            if (_context.Users.Any(a => a.Username == username))
             
            {
                return Ok(_context.Users.Where(a => a.Username == username).SingleOrDefault());
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<UserController>
        [HttpPost]

        public IActionResult Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);

        }

        // PUT api/<UserController>/lex
        [HttpPut("{username}")]
        public IActionResult Put(string username, [FromBody] User user)
        {
            if (_context.Users.Any(a => a.Username == username))
            {
                _context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            if (_context.Users.Any(a => a.Username == username))
            {
                var user = _context.Users.FirstOrDefault(a => a.Username == username);
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
