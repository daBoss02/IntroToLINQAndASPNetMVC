using IntroToLINQAndASPNetMVC.Data;
using IntroToLINQAndASPNetMVC.Models;
using IntroToLINQAndASPNetMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLINQAndASPNetMVC.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateRoleVM vm = new CreateRoleVM(Context.movies, Context.actors);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create([Bind("ActorId", "MovieId", "Credit", "Pay")] CreateRoleVM vm, string secret)
        {
            try
            {
                Actor actor = Context.actors.First(a => a.Id == Int32.Parse(vm.ActorId));
                Movie movie = Context.movies.First(m => m.Id == Int32.Parse(vm.MovieId));
                string credit = vm.Credit;
                int pay = vm.Pay;
                Role newRole = new Role(credit, pay, actor, movie);
                actor.AddRole(newRole);
                movie.AddRole(newRole);
                Context.roles.Add(newRole);
                return RedirectToAction("Info", "Movie", new {id = movie.Id});
            } catch
            {
                return NotFound();
            }
        }
    }
}
