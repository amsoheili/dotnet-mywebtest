using Microsoft.EntityFrameworkCore;

namespace MyWebTest.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Iran",
                    ShortName = "Ir"
                },
                new Country
                {
                    Id = 2,
                    Name = "United States",
                    ShortName = "US"
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Espinas",
                    Address = "Saadat Abad",
                    CountryId = 1,
                    Rating = 4.2
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Chilton",
                    Address = "New York",
                    CountryId = 2,
                    Rating = 4.9
                }
            );
        }
    }
}