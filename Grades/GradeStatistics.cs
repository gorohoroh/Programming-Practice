namespace Grades
{
    public class GradeStatistics
    {
        public string GradeDescription
        {
            get
            {
                string description;
                switch (LetterGrade) {
                    case "A":
                    {
                        description = "Excellent";
                        break;
                    }
                    case "B":
                    {
                        description = "Good";
                        break;
                    }
                    case "C":
                    {
                        description = "Average";
                        break;
                    }
                    case "D":
                    {
                        description = "Below average";
                        break;
                    }
                    default:
                    {
                        description = "Failing";
                        break;
                    }
                }
                return description;
            }
        }
        
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