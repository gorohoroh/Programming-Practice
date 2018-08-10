namespace FoodEquals
{
    public class FoodAsReferenceType
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

        public FoodAsReferenceType(string name, FoodGroup group)
        {
            this.name = name;
            this.group = group;
        }

        public override string ToString()
        {
            return this.name;
        }
    }

    public sealed class CookedFood : FoodAsReferenceType
    {
        private string cookingMethod;

        public string CookingMethod
        {
            get { return cookingMethod; }
        }

        public CookedFood(string cookingMethod, string name, FoodGroup group) : base(name, group)
        {
            this.cookingMethod = cookingMethod;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", cookingMethod, Name);
        }
    }
}