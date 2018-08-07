using System;
using Xunit;

namespace Grades.Tests
{
    public class GradeBookTests
    {
        [Fact]
        public void CalculatesAverageGrade()
        {
            IGradeTracker book = new GradeBook();
            book.AddGrade(75);
            book.AddGrade(89);

            var actualAverageGrade = book.ComputeStatistics().AverageGrade;
            Assert.Equal(82, actualAverageGrade);
        }
        
        [Fact]
        public void CalculatesLowestGrade()
        {
            IGradeTracker book = new GradeBook();
            book.AddGrade(29);
            book.AddGrade(99);
            book.AddGrade(71);

            var actualLowestGrade = book.ComputeStatistics().LowestGrade;
            Assert.Equal(29, actualLowestGrade);
        }
        
        [Fact]
        public void CalculatesHighestGrade()
        {
            IGradeTracker book = new GradeBook();
            book.AddGrade(59);
            book.AddGrade(99.166f);

            var actualHighestGrade = book.ComputeStatistics().HighestGrade;
            Assert.Equal(99.2, actualHighestGrade, precision: 1);
        }
    }
}