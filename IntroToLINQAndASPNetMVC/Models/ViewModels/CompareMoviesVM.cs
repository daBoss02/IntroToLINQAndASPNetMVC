using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntroToLINQAndASPNetMVC.Models.ViewModels
{
    public class CompareMoviesVM
    {
        public string MovieId1 { get; set; }
        public string MovieId2 { get; set; }

        public Movie? Movie1 { get; set; }
        public Movie? Movie2 { get; set; }

        public List<SelectListItem> Movies { get; } = new List<SelectListItem>();

        public CompareMoviesVM(HashSet<Movie> movies)
        {
            foreach (Movie m in movies)
            {
                Movies.Add(new SelectListItem(m.Title, m.Id.ToString()));
            }
        }

        public CompareMoviesVM(string movie1, string movie2, HashSet<Movie> movies)
        {
            foreach (Movie m in movies)
            {
                Movies.Add(new SelectListItem(m.Title, m.Id.ToString()));
            }
            Movie1 = movies.First(m1 => m1.Id == Int32.Parse(movie1));
            Movie2 = movies.First(m2 => m2.Id == Int32.Parse(movie2));

        }

        public CompareMoviesVM() { }
    }
}
