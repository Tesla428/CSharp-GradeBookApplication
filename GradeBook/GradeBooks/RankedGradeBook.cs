using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            double oneFifth = Students.Count / 5;

            var listOfGrades = Students.OrderBy(x => x.Grades);

            double test = ((oneFifth * 4) / listOfGrades.Count()) * 100;

            if (averageGrade > (((oneFifth * 4) / listOfGrades.Count()) * 100))
            {
                return 'A';
            }
            else if (averageGrade > (((oneFifth * 3) / listOfGrades.Count()) * 100))
            {
                return 'B';
            }
            else if (averageGrade > (((oneFifth * 2) / listOfGrades.Count()) * 100))
            {
                return 'C';
            }
            else if (averageGrade > ((oneFifth / listOfGrades.Count()) * 100))
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
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

    }
}
