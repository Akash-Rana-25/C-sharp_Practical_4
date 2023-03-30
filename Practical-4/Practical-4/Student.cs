using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_4
{

    internal class Student
    {
        public string Name;
        public static readonly int marksLength = 5;
        public decimal[] Marks;
        public static decimal AverageMarks;

        public Student(string name, decimal[] marks)
        {
            Name = name;
            Marks = marks;
        }

        public decimal CalculateAverageMarks()
        {
            decimal totalMarks = 0;
            foreach (var item in Marks)
            {
                totalMarks += item;
            }
            AverageMarks = totalMarks / marksLength;
            return AverageMarks;
        }

        public decimal CalculateMaximumMark()
        {
            return Marks.Max();
        }

        public decimal CalculateMinimumMark()
        {
            return Marks.Min();
        }

        public string CalculateGrade()
        {
            decimal totalMarks = Marks.Sum();

            return totalMarks switch
            {
                > 90 => "A",
                > 80 => "B",
                > 70 => "C",
                <= 70 => "D",
            };
        }
    }
}
