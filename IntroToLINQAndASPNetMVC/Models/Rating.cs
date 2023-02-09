using IntroToLINQAndASPNetMVC.Data;

namespace IntroToLINQAndASPNetMVC.Models
{
    public class Rating
    {
        private readonly int _id;
        public int Id { get { return _id; } }
        private int _value;
        public int Value 
        { 
            get { return _value; } 
            set
            {
                if(value > 0 && value < 11)
                {
                    _value = value;
                } else
                {
                    throw new Exception("Rating must be between 1 and 10");
                }
            }
        }

        public User User { get; set; }
        public Movie Movie { get; set; }

        public Rating()
        {
            _id = Context.GetId();
        }

        public Rating(int value, User user, Movie movie)
        {
            _value = value;
            User = user;
            Movie = movie;
        }
    }
}
