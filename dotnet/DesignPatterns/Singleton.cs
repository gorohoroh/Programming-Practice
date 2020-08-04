namespace DesignPatterns
{
    public class President
    {
        private static President instance;

        private President(string firstName, string lastName, string party)
        {
            FirstName = firstName;
            LastName = lastName;
            Party = party;
        }

        public static President GetInstance()
        {
            if (instance == null) instance = new President("Donald", "Trump", "Republican");
            return instance;
        }

        public string LastName { get; }
        public string FirstName { get; }
        public string Party { get; }

        public override string ToString() => $"{FirstName} {LastName}, {Party}";
    }
}