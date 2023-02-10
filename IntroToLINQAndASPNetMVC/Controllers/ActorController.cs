using IntroToLINQAndASPNetMVC.Data;
using IntroToLINQAndASPNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLINQAndASPNetMVC.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            HashSet<Actor> actors = Context.actors;
            return View(actors);
        }
        public IActionResult Info(int id)
        {
            try
            {
                Actor actor = Context.actors.First(actor => actor.Id == id);
                return View("Details", actor);
            } catch (Exception ex)
            {
                return NotFound();
            }

        }
    }
}
