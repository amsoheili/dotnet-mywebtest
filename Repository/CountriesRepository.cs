using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebTest.Contracts;
using MyWebTest.Data;

namespace MyWebTest.Repository;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly MyDbContext _context;
    public CountriesRepository(MyDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    public async Task<Country> GetDetails(int id)
    {
        return await _context.Countries.Include(q => q.Hotels)
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
