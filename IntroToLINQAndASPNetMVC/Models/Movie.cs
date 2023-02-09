using IntroToLINQAndASPNetMVC.Data;

namespace IntroToLINQAndASPNetMVC.Models
{
    public class Movie
    {
        private readonly int _id;
        public int Id { get { return _id; } }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value.Length > 0)
                {
                    _title = value;
                }
                else
                {
                    throw new ArgumentException("Title must be at least one character long");
                }
            }
        }

        private readonly DateTime _releaseDate;
        public DateTime ReleaseDate { get { return _releaseDate; } }
        private int _budgetInMillions;
        public int BudgetInMillions 
        { 
            get { return _budgetInMillions; }
            set
            {
                if (value > 0)
                {
                    _budgetInMillions = value;
                } else
                {
                    throw new ArgumentException("Budget must be greater than 0");
                }
            }
        }

        private HashSet<Role> _roles;
        public HashSet<Role> GetRoles() { return _roles.ToHashSet(); }

        private readonly string _genre;
        public string Genre { get { return _genre; } }
        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> GetRatings()
        {
            return _ratings.ToHashSet();
        }
        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }

        public Movie()
        {
            _id = Context.GetId();
        }
        public Movie(string title, DateTime releaseDate, int budget, string genre)
        {
            _id = Context.GetId();
            Title = title;
            _releaseDate = releaseDate;
            BudgetInMillions = budget;
            _genre = genre;
        }
    }
}
