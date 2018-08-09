using System;
using FoodEquals;
using Xunit;

namespace EqualityComparisonTests
{
    public class Equality
    {
        [Fact]
        public void ObjectEquals_ObjectsOfSameReferenceTypeButDifferentFieldValues_ReturnsFalse()
        {
            Food banana = new Food("banana");
            Food chocolate = new Food("chocolate");
            
            // Two objects of the same reference type but different field values. object.Equals() expected to return false
            Assert.False(banana.Equals(chocolate));
        }

        [Fact]
        public void ObjectEquals_ObjectsOfSameReferenceTypeWithSameFieldValues_ReturnsFalse()
        {
            Food banana = new Food("banana");
            Food banana2 = new Food("banana");
            
            // Two objects of the same reference type and same field values. Since object.Equals() checks for reference equality unless overridden, this also returns false
            // because the two variables reference different instances.
            Assert.False(banana.Equals(banana2));
        }
    }
}