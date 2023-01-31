using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_zad10.Enums;
using APBD_zad10.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APBD_zad10.Services
{
    public class DbRepository : IDbRepository
    {
        private readonly MovieDbContex _contex;

        public DbRepository(MovieDbContex contex)
        {
            this._contex = contex;
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            await _contex.Movie.AddAsync(movie);
            await _contex.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ID)
        {
            var movie = await GetMovieAsync(ID);
            _contex.Movie.Remove(movie);
            await _contex.SaveChangesAsync();
        }

        public async Task<DbAnswer> EditAsync(Movie movie)
        {
            try
            {
                _contex.Movie.Update(movie);
                await _contex.SaveChangesAsync();
                return DbAnswer.OK;
            } 
            catch (Exception)
            {
                if (await MovieExistsAsync(movie.ID)) return DbAnswer.NotFound;
                else throw;
            }
        }

        public async Task<Movie> GetMovieAsync(int? ID) => await _contex.Movie.FirstOrDefaultAsync(m => m.ID == ID);
        public async Task<IEnumerable<Movie>> GetMoviesAsync() =>  await _contex.Movie.ToListAsync();
        public async Task<bool> MovieExistsAsync(int? ID) => await _contex.Movie.AnyAsync(m => m.ID == ID);

        public async Task<MovieGenreViewModel> SearchAsync(string genre, string title)
        {
            IQueryable<string> query = from m in _contex.Movie orderby m.Genre select m.Genre;
            var movies = from m in _contex.Movie select m;

            if (!string.IsNullOrEmpty(title)) movies = movies.Where(m => m.Title.Contains(title.Trim()));
            if (!string.IsNullOrEmpty(genre)) movies = movies.Where(m => m.Genre == genre);

            var model = new MovieGenreViewModel
            {
                Genres = new SelectList(await query.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return model;
        }
    }
}