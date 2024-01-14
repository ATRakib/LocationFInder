using LocationFInder.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace LocationFInder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {


            try
            {
                return await _context.User.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
