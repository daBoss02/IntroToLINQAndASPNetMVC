﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;

namespace IntroToLINQAndASPNetMVC.Models.ViewModels
{
    public class CreateRoleVM
    {
        public List<SelectListItem> Actors { get; } = new List<SelectListItem>();
        public List<SelectListItem> Movies { get; } = new List<SelectListItem>();
        public string ActorId { get; set; }
        public string MovieId { get; set; }
        public string Credit { get; set; }
        public int Pay { get; set; }

        public CreateRoleVM(HashSet<Movie> movies, HashSet<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                Actors.Add(new SelectListItem(actor.Name, actor.Id.ToString()));
            }

            foreach (Movie movie in movies)
            {
                Movies.Add(new SelectListItem(movie.Title, movie.Id.ToString()));
            }
        }
        public CreateRoleVM()
        {

        }
    }
}
