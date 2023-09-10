using Microsoft.EntityFrameworkCore;

namespace GaleriAPI.Data
{
    public class GaleriDbContext : DbContext
    {
        public GaleriDbContext(DbContextOptions<GaleriDbContext> options) : base(options)
        {

        }

        public DbSet<Tablo> Tablolar => Set<Tablo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tablo>().HasData(
                    new Tablo()
                    {
                        Id = 1,
                        Ressam = "Pablo Picasso",
                        ResminYapilmaTarihi = new DateTime(1950, 10, 28)
                    },

                    new Tablo()
                    {
                        Id = 2,
                        Ressam = "Leonardo da Vinci",
                        ResminYapilmaTarihi = new DateTime(1496, 1, 8)
                    },

                    new Tablo()
                    {
                        Id = 3,
                        Ressam = "Salvador Dali",
                        ResminYapilmaTarihi = new DateTime(1972, 9, 10)
                    }
                );
        }
    }
}
