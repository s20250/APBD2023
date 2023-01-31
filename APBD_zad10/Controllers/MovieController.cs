using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APBD_zad10.Enums;
using APBD_zad10.Models;
using APBD_zad10.Services;

namespace APBD_zad10.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IDbRepository _repository;

        public MoviesController(IDbRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IActionResult> Index(string genre, string title) => View(await _repository.SearchAsync(genre, title));
        public IActionResult Create() => View();

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var movie = await _repository.GetMovieAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) NotFound();
            var movie = await _repository.GetMovieAsync(id);
            if (movie == null) NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.ID) return NotFound();

            switch (ModelState.IsValid)
            {
                case false:
                    return View(movie);
            }
            var answer = await _repository.EditAsync(movie);
            if (answer == DbAnswer.NotFound) return NotFound();
            else return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            switch (id)
            {
                case null:
                    return NotFound();
            }
            var movie = await _repository.GetMovieAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}