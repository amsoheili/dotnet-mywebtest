using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebTest.Data;

namespace MyWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HotelDbContext _context;
        public CountriesController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Post country", new { id = country.Id }, country);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
