using IntroToLINQAndASPNetMVC.Data;
using IntroToLINQAndASPNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace IntroToLINQAndASPNetMVC.Controllers
{
    public class MovieController : Controller
    {

        public decimal CalculateOverallRating(Movie movie)
        {
            HashSet<Rating> ratings = movie.GetRatings();
            if (ratings.Any())
            {
                return decimal.Round(ratings.Average(r => (decimal)r.Value), 2);
            } else
            {
                return 0;
            }
        }
        public IActionResult Index()
        { 
            ViewBag.PageTitle = "All Movies";
            return View(Context.movies);
        }
        public IActionResult GetMovieInfo(int id)
        {
            try
            {
                Movie movie = Context.movies.First(m =>
                {
                    return m.Id == id;
                });
                ViewBag.Rating = CalculateOverallRating(movie);
                return View("Details", movie);
            } catch(Exception ex)
            {
                return NotFound();
            }
        }
        public IActionResult GetAllInGenre(string genre)
        {
            ViewBag.Title = $"All Movies in the {genre} genre";
            try
            {
                HashSet<Movie> movies = Context.movies.Where(m =>
                {
                    return m.Genre.ToLower() == genre.ToLower();
                }).ToHashSet();
                ViewBag.Amount = movies.Count;
                return View("Index", movies);
            } catch (Exception ex)
            {
                ViewBag.Message = $"No movies were found in the {genre} genre";
                return View();
            }
        }
        public IActionResult MoviesInBudget(int lower, int upper)
        {
            ViewBag.PageTitle = $"Movies in Budget between {lower} million and {upper} million";
            if ( lower < 0 && upper < lower)
            {
                ViewBag.Message = "Cannot have a negative budget, or an upper budget lower than a lower budget";
                return View();
            } else
            {
                HashSet<Movie> movies = Context.movies.Where(m =>
                {
                    return m.BudgetInMillions >= lower && m.BudgetInMillions <= upper;
                }).ToHashSet();
                return View("Index", movies);
            }
        }
        public IActionResult MoviesInThe90s()
        {
            ViewBag.PageTitle = "Movies From the 90's";
            HashSet<Movie> movies = Context.movies.Where(m =>
            {
                return m.ReleaseDate.Year >= 1990 && m.ReleaseDate.Year < 2000;
            }).ToHashSet();
            return View("Index", movies);
        }
    }
}
