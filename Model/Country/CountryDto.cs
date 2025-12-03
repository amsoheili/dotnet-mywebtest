using System;
using MyWebTest.Model.Hotel;

namespace MyWebTest.Model.Country;

public class CountryDto : BaseCountry
{
    public int Id { get; set; }

    public List<HotelDto> Hotels { get; set; } = [];
}
