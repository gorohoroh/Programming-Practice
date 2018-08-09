using FoodEquals;
using Xunit;

namespace EqualityComparisonTests {
    public class ObjectEqualsStatic
    {
        [Fact]
        public void ObjectEqualsStatic_AvoidsNREs_ReturnsFalse()
        {
            Food food = new Food("banana");
            
            // The instance method object.Equals() would cause a NRE when invoked on a null reference; to avoid this, the static Object.Equals() is used that takes two parameters,
            // either of which can be null. The static method provides null checking, and if neither parameter is null, it calls the instance method.
            Assert.False(Equals(null, food));
        }

        [Fact]
        public void ObjectEqualsStatic_TwoNullsAreAlwaysEqual_ReturnsTrue()
        {
            Assert.True(Equals(null, null));
        }
    }
}