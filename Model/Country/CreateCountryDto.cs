using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebTest.Model.Country;

public class CreateCountryDto : BaseCountry
{
}

public class UpdateCountryDto : BaseCountry
{
    public int Id { get; set; }

}
