using System;

namespace FoodEquals
{
    public struct FoodItem : IEquatable<FoodItem>
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

        public static bool operator ==(FoodItem lhs, FoodItem rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(FoodItem lhs, FoodItem rhs)
        {
            return !(lhs == rhs);
        }


        public bool Equals(FoodItem other)
        {
            return name == other.name && group == other.group;
        }

        public override bool Equals(object obj)
        {
            if (obj is FoodItem) {
                return Equals((FoodItem)obj);
            }

            return false;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public enum FoodGroup { Meet, Fruit, Vegetable, Sweets }
}