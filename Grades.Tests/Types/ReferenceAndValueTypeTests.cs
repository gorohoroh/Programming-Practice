using System;
using Xunit;

namespace Grades.Tests.Types
{
    public class ReferenceAndValueTypeTests
    {
        
        [Fact]
        public void ComparingTwoStringsByValueIgnoringCaseReturnsTrue()
        {
            string firstString = "Jura";
            string secondString = "jura";
            bool result = String.Equals(firstString, secondString, StringComparison.InvariantCultureIgnoreCase);

            Assert.True(result);
        }
        
        [Fact]
        public void VariablesOfValueTypeHoldValues()
        {
            int integer1 = 100;
            int integer2 = integer1;
            integer1 = 4;
            
            Assert.NotEqual(integer1, integer2);
        }
        
        [Fact]
        public void TwoVariablesOfReferenceTypeHoldReferenceToTheSameObject()
        {
            GradeBook gradeBook1 = new GradeBook();
            GradeBook gradeBook2 = gradeBook1;
            gradeBook1.Name = "Gradebook one";
            
            Assert.Equal(gradeBook1.Name, gradeBook2.Name);
        }
        
        [Fact]
        public void VariableOfValueTypePassedByRef()
        {
            int number = 46;
            IncrementInteger(ref number);
            
            Assert.Equal(47, number);
            
        }

        private void IncrementInteger(ref int number) => number++;
        
        [Fact]
        public void ImmutableDateTimeAndItsPureMethods()
        {
            DateTime dateTime = new DateTime(2017, 01, 24);
            dateTime.AddMonths(6); // Pure method on a value type, new value isn't used unless explicitly assigned
            
            Assert.NotEqual(07, dateTime.Month);
        }
        
        [Fact]
        public void StringsAreImmutableReferenceTypes()
        {
            string name = "jura";
            name = name.ToUpper(); // Only works because explicitly assigned
            
            Assert.Equal("JURA", name);
        }
    }
}