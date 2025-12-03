using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebTest.Model.Country;

public abstract class BaseCountry
{

    [Required]
    public string Name { get; set; }
    public string ShortName { get; set; }
}
