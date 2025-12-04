using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebTest.Contracts;
using MyWebTest.Data;
using MyWebTest.Model.Hotel;

namespace MyWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IHotelsRepository _hotelsRepository;

        public HotelsController(
            IMapper mapper,
            IHotelsRepository hotelsRepository
        )
        {
            _mapper = mapper;
            _hotelsRepository = hotelsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> Get()
        {
            var hotels = await _hotelsRepository.GetAllAsync();
            return _mapper.Map<List<HotelDto>>(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> Get(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return _mapper.Map<HotelDto>(hotel);
        }


        [HttpPost]
        public async Task<ActionResult> AddHotel(CreateHotelDto hotel)
        {
            var myHotel = _mapper.Map<Hotel>(hotel);
            await _hotelsRepository.AddAsync(myHotel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotel(int id, UpdateHotelDto updateHotelDto)
        {
            if (id != updateHotelDto.Id)
            {
                return BadRequest();
            }
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateHotelDto, hotel);
            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            await _hotelsRepository.DeleteAsync(id);
            return Ok("successfully deleted");
        }

    }
}
