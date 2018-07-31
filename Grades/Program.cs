using System;

namespace Grades
{
    class Program
    {
        static void Main()
        {
            GradeBook book = new GradeBook();
            book.NameChanged += OnNameChanged;
            book.Name = "My gradebook";
            book.AddGrade(75);
            book.AddGrade(99);
            book.AddGrade(79.5f);
            book.AddGrade(90.1f);
            book.Name = "My updated gradebook";

            var stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            Console.WriteLine("Average grade: " + stats.AverageGrade);
            Console.WriteLine("{0}: {1:F1}", "Lowest grade", stats.LowestGrade);
            Console.WriteLine($"Highest grade: {stats.HighestGrade:F1}");

        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook is changing name from {args.ExistingName} to {args.NewName}");
        }

    }
}