using System;
using Xunit;

namespace EqualityComparisonTests
{
    public class EqualityOperator
    {
        [Fact]
        public void PrimitiveValueTypes_OperatorAndEqualsCheckValueEquality()
        {
            int i1 = 3;
            int i2 = 3;

            bool whatEqualsReturns = i1.Equals(i2);
            bool whatOperatorReturns = i1 == i2;
            
            // For primitive value types, object.Equals() and == both check for value equality.
            Assert.True(whatEqualsReturns == whatOperatorReturns);
        }

        [Fact]
        public void ReferenceTypes_OperatorAndEqualsCheckReferenceEquality()
        {
            UriBuilder builder = new UriBuilder {Host = "google.com"};
            UriBuilder builder2 = builder;

            bool whatEqualsReturns = builder.Equals(builder2);
            bool whatOperatorReturns = builder == builder2;
            
            // For reference types, object.Equals() and == both check for reference equality.
            Assert.True(whatEqualsReturns == whatOperatorReturns);
        }

        [Fact]
        public void OtherValueTypes_OperatorNotAvailableUnlessOverloaded()
        {
            SampleStruct myStruct = new SampleStruct();
            SampleStruct myOtherStruct = new SampleStruct();

            bool whatEqualsReturns = myStruct.Equals(myOtherStruct);
            bool whatOperatorReturns = myStruct == myOtherStruct;
            
            // Checking equality of two non-primitive value types with == causes compiler error if the operator is not overloaded
            // in the given type. We had to provide a stub overload in SampleStruct for the test to even compile, and since the overload
            // calls object.Equals(), which checks for value equality when using value types, the outputs are the same.
            Assert.True(whatEqualsReturns == whatOperatorReturns);
        }

        [Fact]
        public void GenericTypes_OperatorAlwaysTreatsThemAsObject()
        {
            string string1 = "something";
            string string2 = String.Copy(string1);

            bool AreGenericArgsEqualWithOperator<T>(T x, T y) where T: class => x == y;
            bool AreGenericArgsEqualWithEquals<T>(T x, T y) => Equals(x, y);

            bool whatEqualsReturns = AreGenericArgsEqualWithEquals(string1, string2);
            bool whatOperatorReturns = AreGenericArgsEqualWithOperator(string1, string2);

            // The static Equals() predictably checks for value equality because that's how it's implemented for strings;
            // but the operator checks for reference equality because it doesn't know what the generic type will resolve into,
            // thus treats the variables being checked for equality as two objects.
            Assert.False(whatEqualsReturns == whatOperatorReturns);
        }
        
        [Fact]
        public void Tuples_OperatorAndEqualsActDifferently()
        {
            Tuple<int, int> myTuple = Tuple.Create(1, 3);
            Tuple<int, int> myOtherTuple = new Tuple<int, int>(1,3);

            bool whatEqualsReturns = myTuple.Equals(myOtherTuple);
            bool whatOperatorReturns = myTuple == myOtherTuple;
            
            // object.Equals() is overridden for Tuple<T1, T2> to check value equality. However, there's no == operator overload 
            // for this type that does the same, which means the == operator checks for reference equality by default.
            // This means, the two ways of checking equality will return opposite results in this case.
            Assert.False(whatEqualsReturns == whatOperatorReturns);
            
        }
    }

    public struct SampleStruct
    {
        public static bool operator ==(SampleStruct lhs, SampleStruct rhs) => Equals(lhs, rhs);
        public static bool operator !=(SampleStruct lhs, SampleStruct rhs) => !(lhs == rhs);
    }
}