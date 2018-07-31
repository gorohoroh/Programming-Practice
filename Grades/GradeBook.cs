﻿using System;
using System.Collections.Generic;
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
                if (!String.IsNullOrEmpty(value))
                {
                    if (name != value)
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
    }
}