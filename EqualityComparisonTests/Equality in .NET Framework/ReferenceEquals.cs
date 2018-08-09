using Xunit;

namespace EqualityComparisonTests {
    public class ReferenceEquals
    {

        [Fact]
        public void ReferenceEquals_TwoStrings_InternedByFramework_ReturnsTrue()
        {
            string myString = "something";
            string mySecondString = "something";
            
            // Even though it looks like the two variables should not be equal when compared by reference, they're auto-interned by .NET Core,
            // and this means since they share the same value, they're made to use the same reference.
            Assert.True(ReferenceEquals(myString, mySecondString));
        }

        [Fact]
        public void ReferenceEquals_TwoStrings_WithoutInterning_ReturnsFalse()
        {
            string myString = "something";
            string mySecondString = string.Copy(myString);
            
            // Calling string.Copy() makes sure that the two variables are two distinct references, albeit pointing to the same value. ReferenceEquals() thus returns false in this case.
            Assert.False(ReferenceEquals(myString, mySecondString));
        }
    }
}