using IntroToLINQAndASPNetMVC.Data;

namespace IntroToLINQAndASPNetMVC.Models
{
    public class User
    {
        private readonly int _id;
        public int Id { get { return _id; } }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value.Length > 2 && value.Length <= 30)
                {
                    _userName = value;
                } else
                {
                    throw new ArgumentException("Length must be between 3 and 30 characters long");
                }
            }
        }

        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> Ratings { get { return _ratings.ToHashSet(); } }
        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }

        public User() 
        {
            _id = Context.GetId();
        }

        public User(string username)
        {
            _id = Context.GetId();
            UserName = username;
        }
    }
}
