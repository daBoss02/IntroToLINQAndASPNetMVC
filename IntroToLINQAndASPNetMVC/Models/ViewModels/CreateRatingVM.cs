using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntroToLINQAndASPNetMVC.Models.ViewModels
{
    public class CreateRatingVM
    {
        public List<SelectListItem> Movies { get; } = new List<SelectListItem>();

        public string UserName { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public string MovieId { get; set; }



        public CreateRatingVM(HashSet<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                Movies.Add(new SelectListItem(movie.Title, movie.Id.ToString()));
            }
        }
        public CreateRatingVM() { }
    }
}
