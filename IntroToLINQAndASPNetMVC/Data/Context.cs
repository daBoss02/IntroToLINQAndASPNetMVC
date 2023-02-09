using IntroToLINQAndASPNetMVC.Models;

namespace IntroToLINQAndASPNetMVC.Data
{
    public static class Context
    {
        private static int _actorId = 0;
        public static int GetId()
        {
            _actorId++;
            return _actorId;
        }
        public static HashSet<Actor> actors = new HashSet<Actor>();
        public static HashSet<Movie> movies = new HashSet<Movie>();
        public static HashSet<Rating> ratings = new HashSet<Rating>();
        public static HashSet<Role> roles = new HashSet<Role>();
        public static HashSet<User> users = new HashSet<User>();

        private static void _seedMethod()
        {
            Movie movie1 = new Movie("Die Hard", new DateTime(1988, 1, 1), 100, "Action");
            Movie movie2 = new Movie("Blade Runner", new DateTime(1972, 1, 1), 70, "Action");
            Movie movie3 = new Movie("Scream", new DateTime(1999, 1, 1), 200, "Horror");
            Movie movie4 = new Movie("Back to the Future", new DateTime(1985, 7, 13), 19, "Comedy");

            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);
            movies.Add(movie4);

            User user1 = new User("PopoClown");
            User user2 = new User("JJKSublime");
            User user3 = new User("BossBaby27");

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            Rating rating1 = new Rating(7, user1, movie2);
            user1.AddRating(rating1);
            movie2.AddRating(rating1);
            Rating rating2 = new Rating(2, user3, movie1);
            user3.AddRating(rating2);
            movie1.AddRating(rating2);
            Rating rating3 = new Rating(10, user2, movie3);
            user2.AddRating(rating3);
            movie3.AddRating(rating3);
            Rating rating4 = new Rating(5, user2, movie1);
            user2.AddRating(rating4);
            movie1.AddRating(rating4);

            Actor actor1 = new Actor("Ryan Renolds", 20_000_000);
            Actor actor2 = new Actor("Johnny Depp", 20_000_000);
            Actor actor3 = new Actor("Robert Downey Jr.", 70_000_000);
            Actor actor4 = new Actor("Chris Hemsworth", 15_000_000);

            actors.Add(actor1);
            actors.Add(actor2);
            actors.Add(actor3);
            actors.Add(actor4);
        }
        static Context()
        {
            _seedMethod();
        }
    }
}
