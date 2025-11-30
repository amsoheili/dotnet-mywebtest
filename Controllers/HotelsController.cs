using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebTest.Data;

namespace MyWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel{Id=1,Name="Jamshid",Address="kermanshah taghe bostan", Rating=4.0},
            new Hotel{Id=2,Name="Espinas",Address="kermanshah taghe bostan", Rating=4.8},
        };

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var searchedHotel = hotels.Find(h => h.Id == id);
            if (searchedHotel == null)
            {
                return NotFound();
            }
            return Ok(searchedHotel);
        }

        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if (hotels.Any(h => h.Id == newHotel.Id))
            {
                return BadRequest("Hotel already exists.");
            }
            hotels.Add(newHotel);
            return Ok("Successfully added");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel hotel)
        {
            var updatingHotel = hotels.Find(h => h.Id == id);
            if (updatingHotel == null)
            {
                return NotFound("Hotel not found");
            }

            updatingHotel.Name = hotel.Name;
            updatingHotel.Rating = hotel.Rating;
            updatingHotel.Address = hotel.Address;
            return Ok("Successfully updated the hotel.");
        }

        [HttpDelete("{id}")]
        public ActionResult<Hotel> Delete(int id)
        {
            var removingHotel = hotels.Find(h => h.Id == id);
            if (removingHotel == null)
            {
                return BadRequest("No such Hotel");
            }
            hotels.Remove(removingHotel);
            return Ok("Hotel removed successfully");
        }

    }
}
