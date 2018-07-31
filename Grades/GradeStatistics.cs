namespace Grades
{
    public class GradeStatistics
    {
        public string LetterGrade
        {
            get
            {
                if (AverageGrade >= 90) {
                    return "A";
                }
                else if (AverageGrade >= 80)
                    return "B";
                else if (AverageGrade >= 70) {
                    return "C";
                }
                else if (AverageGrade >= 60) {
                    return "D";
                }
                else {
                    return "F";
                }
            }
        }
        
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}