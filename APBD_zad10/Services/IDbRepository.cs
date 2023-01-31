using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_zad10.Enums;
using APBD_zad10.Models;

namespace APBD_zad10.Services
{
    public interface IDbRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(int? ID);
        Task CreateMovieAsync(Movie movie);
        Task<DbAnswer> EditAsync(Movie movie);
        Task<bool> MovieExistsAsync(int? ID);
        Task DeleteAsync(int ID);
        Task<MovieGenreViewModel> SearchAsync(string genre, string title);
    }
}
