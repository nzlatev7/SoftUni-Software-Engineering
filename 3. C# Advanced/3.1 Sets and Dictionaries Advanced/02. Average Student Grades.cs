using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Averag_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine().Split(" ");
                string name = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                    continue;
                }

                List<decimal> grades = new List<decimal>();
                grades.Add(grade);

                students.Add(name, grades);
            }

            foreach (var student in students)
            {
                //John -> 5.20 3.20 (avg: 4.20)

                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
