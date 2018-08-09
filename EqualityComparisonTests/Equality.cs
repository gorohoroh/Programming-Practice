using System;
using FoodEquals;
using Xunit;

namespace EqualityComparisonTests
{
    public class Equality
    {
        [Fact]
        public void ObjectEqualsNotOverridden()
        {
            Food banana = new Food("banana");
            Food chocolate = new Food("chocolate");
            
            // Two objects of the same reference type but different field values. object.Equals() expected to return false
            Assert.False(banana.Equals(chocolate));

        }
    }
}