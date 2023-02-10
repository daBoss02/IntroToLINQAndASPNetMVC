using IntroToLINQAndASPNetMVC.Data;

namespace IntroToLINQAndASPNetMVC.Models
{
    public class Actor
    {
        private int _salary;
        public int Salary { get { return _salary; } }
        private readonly int _id;
        public int Id { get { return _id; } }
        private string _name;

        private HashSet<Role> _roles = new HashSet<Role>();

        public HashSet<Role> Roles { get { return _roles.ToHashSet(); } }
        public void AddRole(Role role)
        {
            _roles.Add(role);
        }
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 0)
                {
                    _name = value;
                } else
                {
                    throw new ArgumentException("Name must be at least one character long");
                }
            }
        }
        public Actor(string name, int salary)
        {
            Name = name;
            _salary = salary;
            _id = Context.GetId();
        }
    }
}
