using System;
using AutoMapper;
using MyWebTest.Data;
using MyWebTest.Model.Country;
using MyWebTest.Model.Hotel;

namespace MyWebTest.Configuration;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();
    }

}
