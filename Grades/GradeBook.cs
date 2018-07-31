using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades;
        private string name;
        public event NameChangedDelegate NameChanged;

        public string Name
        {
            get { return name;}
            
            set {
                if (String.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name should not be null or empty");
                }

                if (name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs
                    {
                        ExistingName = name, 
                        NewName = value
                    };

                    NameChanged(this, args);
                }
                    
                name = value;
            }
        }

        public GradeBook()
        {
            name = "Empty";
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

        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--) {
                destination.WriteLine(grades[i-1]);
            }
        }
    }
}