using APBD_zad10.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using APBD_zad10.EntityTypeConfigurations;

namespace APBD_zad10.Models
{
    public class MovieDbContex : DbContext
    {
        public MovieDbContex() { }
        public MovieDbContex(DbContextOptions<MovieDbContex> options) : base(options) { }

        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieEntityTypeConfiguration());
        }
    }
}
