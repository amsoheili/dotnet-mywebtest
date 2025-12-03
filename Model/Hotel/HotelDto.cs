using System;

namespace MyWebTest.Model.Hotel;

public class HotelDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public double Rating { get; set; }

}
