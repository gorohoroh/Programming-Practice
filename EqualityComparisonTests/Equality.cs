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
            
            // Two objects of the same reference type but different field values. object.Equals() expected to return false.
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

        [Fact]
        public void ObjectEquals_String_BothEqualsMethodsCheckValueEquality_TwoStringsSameValue_ReturnsTrue()
        {
            string banana = "banana";
            string banana2 = string.Copy(banana);
            
            // object.Equals() is overridden in the string type to execute value comparison, and there's also a non-overridden string.Equals(string value). Whichever of them is used,
            // comparing two string values containing the same characters in the same order is expected to return true.
            Assert.True(
                banana.Equals((object)banana2)
                    .Equals(
                        banana.Equals(banana2
                        )
                    )
                );
        }

        [Fact]
        public void ObjectEquals_Tuple_ChecksValueEquality_TwoTuplesSameValues_ReturnsTrue()
        {
            Tuple<string, int> tuple = new Tuple<string, int>("something", 1);
            Tuple<string, int> tuple2 = new Tuple<string, int>("something", 1);
            
            // object.Equals() for tuples compares value equality.
            Assert.True(tuple.Equals(tuple2));
        }

        [Fact]
        public void ObjectEquals_ValueTypes_Struct_TwoInstancesSameFieldValue_ReturnsTrue()
        {
            FoodStruct foodStruct = new FoodStruct("banana");
            FoodStruct foodStruct2 = new FoodStruct("banana");
            
            Assert.True(foodStruct.Equals(foodStruct2));
        }

        [Fact]
        public void ObjectEquals_Null_AlwaysNotEqualToNonNull_ReturnsFalse()
        {
            Food food = new Food("banana");
            
            Assert.False(food.Equals(null));
        }

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