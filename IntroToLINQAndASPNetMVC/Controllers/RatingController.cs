using IntroToLINQAndASPNetMVC.Data;
using IntroToLINQAndASPNetMVC.Models;
using IntroToLINQAndASPNetMVC.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLINQAndASPNetMVC.Controllers
{
    public class RatingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            CreateRatingVM vm = new CreateRatingVM(Context.movies);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create([Bind("MovieId", "Value", "Comment", "UserName")] CreateRatingVM vm)
        {
            Movie movie = Context.movies.First(m => m.Id == Int32.Parse(vm.MovieId));
            string comment = vm.Comment;
            int value = vm.Value;
            string userName = vm.UserName;
            User user = new User();
            try
            {
                user = Context.users.First(u => u.UserName == userName);
            } catch
            {
                user = new User(userName);
            }
            Rating newRating = new Rating(value, user, movie, comment);
            user.AddRating(newRating);
            movie.AddRating(newRating);
            Context.ratings.Add(newRating);
            return RedirectToAction("Info", "Movie", new {id = movie.Id});
        }
    }
}
