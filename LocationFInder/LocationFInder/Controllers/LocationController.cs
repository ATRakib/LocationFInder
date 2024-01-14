using LocationFInder.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationFInder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Location.ToListAsync();
        }

    }
}
