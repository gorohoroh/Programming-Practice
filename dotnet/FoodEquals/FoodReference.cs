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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;

            FoodAsReferenceType other = obj as FoodAsReferenceType;
            return name == other.name && group == other.group;
        }

        public static bool operator ==(FoodAsReferenceType lhs, FoodAsReferenceType rhs) => Equals(lhs, rhs);
        public static bool operator !=(FoodAsReferenceType lhs, FoodAsReferenceType rhs) => !(lhs == rhs);

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ group.GetHashCode();
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