using IntroToLINQAndASPNetMVC.Data;

namespace IntroToLINQAndASPNetMVC.Models
{
    public class Role
    {
        private readonly int _id;
        public int Id { get { return _id; } }
        private string _credit;
        public string Credit
        {
            get { return _credit; }
            set
            {
                if (value.Length > 0)
                {
                    _credit = value;
                }
                else
                {
                    throw new Exception("Credit must have a value");
                }
            }
        }

        private int _pay;
        public int Pay 
        { 
            get { return _pay; }
            set
            {
                if (value >= 0)
                {
                    _pay = value;
                }
                else
                {
                    throw new Exception("Actor must be paid");
                }
            }
        }

        private HashSet<Role> _roles;
        public HashSet<Role> GetRoles() { return _roles.ToHashSet(); }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }

        public Role() 
        {
            _id = Context.GetId();
        }
    }
}
