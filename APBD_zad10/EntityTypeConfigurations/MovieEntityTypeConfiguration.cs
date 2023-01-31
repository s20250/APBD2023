using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_zad10.Models;

namespace APBD_zad10.EntityTypeConfigurations
{
    public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(e => e.ID).HasName("Movie_PK");
            builder.Property(e => e.ID).UseIdentityColumn();

            builder.Property(e => e.Title).HasMaxLength(256).IsRequired();

            builder.Property(e => e.ReleaseDate).IsRequired();

            builder.Property(e => e.Genre).HasMaxLength(128).IsRequired();

            builder.Property(e => e.Price).IsRequired();

            builder.Property(e => e.Rating).HasMaxLength(64);

            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                }
            };

            builder.HasData(movies);
        }
    }
}