using System;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main()
        {
            GradeBook book = new GradeBook();
            book.NameChanged += OnNameChanged;
            
            PromptForGradebookName(book);
            EnterGrades(book);
            SaveGradesToFile(book);

            var stats = book.ComputeStatistics();

            WriteStatsToConsole(book, stats);
        }

        private static void WriteStatsToConsole(GradeBook book, GradeStatistics stats)
        {
            Console.WriteLine(book.Name);
            Console.WriteLine("Average grade: " + stats.AverageGrade);
            Console.WriteLine("{0}: {1:F1}", "Lowest grade", stats.LowestGrade);
            Console.WriteLine($"Highest grade: {stats.HighestGrade:F1}");
            Console.WriteLine($"Letter grade: {stats.LetterGrade}");
            Console.WriteLine($"Grade description: {stats.GradeDescription}");
        }

        private static void SaveGradesToFile(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt")) {
                book.WriteGrades(outputFile);
            }
        }

        private static void EnterGrades(GradeBook book)
        {
            book.AddGrade(75);
            book.AddGrade(99);
            book.AddGrade(79.5f);
            book.AddGrade(90.1f);
        }

        private static void PromptForGradebookName(GradeBook book)
        {
            Console.WriteLine("Enter a gradebook name:");

            try {
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException exception) {
                Console.WriteLine(exception);
            }
            catch (Exception) {
                Console.WriteLine("Something went wrong. Did it?");
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook is changing name from {args.ExistingName} to {args.NewName}");
        }

    }
}