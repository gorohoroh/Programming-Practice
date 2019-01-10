namespace FoodEquals
{
    public class Food
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        public Food(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public struct FoodStruct
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        public FoodStruct(string name)
        {
            this.name = name;
        }
    }
}