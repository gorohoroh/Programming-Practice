using System;
using System.Collections.Generic;
using System.Linq;

namespace Grades
{
    class Program
    {
        static void Main()
        {
            GradeBook book = new GradeBook();
            book.Name = "My gradebook";
            book.AddGrade(75);
            book.AddGrade(99);
            book.AddGrade(79.5f);
            book.AddGrade(90.1f);

            var stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            Console.WriteLine("Average grade: " + stats.AverageGrade);
            Console.WriteLine("{0}: {1:F1}", "Lowest grade", stats.LowestGrade);
            Console.WriteLine($"Highest grade: {stats.HighestGrade:F1}");

        }
    }

    public class GradeBook
    {
        private List<float> grades;
        private string name;

        public string Name
        {
            get { return name;}
            
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }

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

    public class GradeStatistics
    {
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}