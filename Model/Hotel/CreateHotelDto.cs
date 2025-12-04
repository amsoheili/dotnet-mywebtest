using System;

namespace MyWebTest.Model.Hotel;

public class CreateHotelDto
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public double Rating { get; set; }

    public int CountryId { get; set; }
}
