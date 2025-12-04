using System;
using AutoMapper;
using MyWebTest.Contracts;
using MyWebTest.Data;

namespace MyWebTest.Repository;

public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
{
    private readonly MyDbContext _context;
    public HotelsRepository(MyDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }
}
