using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebTest.Data;

namespace MyWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public HotelsController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            return await _context.Hotels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return hotel;
        }

    }
}
