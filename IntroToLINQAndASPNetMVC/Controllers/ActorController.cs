using IntroToLINQAndASPNetMVC.Data;
using IntroToLINQAndASPNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLINQAndASPNetMVC.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HighestPaidActor()
        {
            HashSet<Actor> orderedActors = Context.actors.OrderByDescending(actor => actor.Salary).ToHashSet();
            return View("ActorDetails", orderedActors);
        }
    }
}
