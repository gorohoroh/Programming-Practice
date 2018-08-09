namespace FoodEquals
{
    public struct FoodItem
    {
        private readonly string name;
        private readonly FoodGroup group;

        public string Name
        {
            get { return name; }
        }

        public FoodGroup Group
        {
            get { return group; }
        }

        public FoodItem(string name, FoodGroup group)
        {
            this.name = name;
            this.group = group;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public enum FoodGroup { Meet, Fruit, Vegetable, Sweets }
}