using System;
using MyWebTest.Data;

namespace MyWebTest.Contracts;

public interface ICountriesRepository : IGenericRepository<Country>
{
    Task<Country> GetDetails(int id);
}
