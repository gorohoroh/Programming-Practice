using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(75);
            book.AddGrade(99);
            book.AddGrade(79.5f);
            book.AddGrade(90.1f);

            var stats = book.ComputeStatistics();

            Console.WriteLine("Average grade: " + stats.AverageGrade);
            Console.WriteLine("Lowest grade: " + stats.LowestGrade);
            Console.WriteLine("Highest grade: " + stats.HighestGrade);

        }
    }

    class GradeBook
    {
        private List<float> grades;

        public GradeBook()
        {
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics statistics = new GradeStatistics();

            statistics.AverageGrade = grades.Average();
            statistics.HighestGrade = grades.Max();
            statistics.LowestGrade = grades.Min();
            
            return statistics;
        }
    }

    internal class GradeStatistics
    {
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}