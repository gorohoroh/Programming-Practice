using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        protected List<float> grades;
        public override event NameChangedDelegate NameChanged;

        public GradeBook()
        {
            name = "Empty";
            grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics statistics = new GradeStatistics();

            statistics.AverageGrade = grades.Average();
            statistics.HighestGrade = grades.Max();
            statistics.LowestGrade = grades.Min();
            
            return statistics;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--) {
                destination.WriteLine(grades[i-1]);
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
    }
}