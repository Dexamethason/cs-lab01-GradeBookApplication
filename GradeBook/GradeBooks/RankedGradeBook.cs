using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            var counter = 0;
            
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade > averageGrade)
                {
                    counter++;
                }
            }

            var gradePercent = (counter * 100) / Students.Count;
            
            if (gradePercent >= 0 &&  gradePercent < 20)
            {
                return 'A';
            }
            else if (gradePercent >= 20 && gradePercent < 40)
            {
                return 'B';
            }
            else if (gradePercent >= 40 && gradePercent < 60)
            {
                return 'C';
            }
            else if (gradePercent >= 60 && gradePercent < 80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}