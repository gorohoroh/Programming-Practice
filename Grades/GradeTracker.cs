using System;
using System.IO;

namespace Grades
{
    public abstract class GradeTracker
    {
        protected string name;
        public virtual event NameChangedDelegate NameChanged;

        public string Name
        {
            get { return name; }

            set
            {
                if (String.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name should not be null or empty");
                }

                if (name != value && NameChanged != null) {
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

        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
    }
}