using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebTest.Configuration;
using MyWebTest.Contracts;
using MyWebTest.Data;
using MyWebTest.Model.Country;

namespace MyWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IMapper _mapper;
        public CountriesController(
            ICountriesRepository countriesRepository,
            IMapper mapper)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> Get()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);

            await _countriesRepository.AddAsync(country);

            return Ok("Good");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);
            if (country == null)
            {
                return NotFound();
            }
            return _mapper.Map<CountryDto>(country);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry(int id, UpdateCountryDto updateCountry)
        {

            if (id != updateCountry.Id)
            {
                return BadRequest("your so bad");
            }
            Country country;
            try
            {
                country = await _countriesRepository.GetAsync(id);

            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountry, country);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _countriesRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
