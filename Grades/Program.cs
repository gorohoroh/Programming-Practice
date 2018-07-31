﻿using System;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main()
        {
            GradeBook book = new GradeBook();
            book.NameChanged += OnNameChanged;
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
            
            book.AddGrade(75);
            book.AddGrade(99);
            book.AddGrade(79.5f);
            book.AddGrade(90.1f);

            using (StreamWriter outputFile = File.CreateText("grades.txt")) {
                book.WriteGrades(outputFile);
            }

            var stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            Console.WriteLine("Average grade: " + stats.AverageGrade);
            Console.WriteLine("{0}: {1:F1}", "Lowest grade", stats.LowestGrade);
            Console.WriteLine($"Highest grade: {stats.HighestGrade:F1}");
            Console.WriteLine($"Letter grade: {stats.LetterGrade}");
            Console.WriteLine($"Grade description: {stats.GradeDescription}");

        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook is changing name from {args.ExistingName} to {args.NewName}");
        }

    }
}