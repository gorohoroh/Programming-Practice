using System.Linq;

namespace Grades {
    class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            grades.Remove(grades.Min());
            return base.ComputeStatistics();
        }
        
    }
}