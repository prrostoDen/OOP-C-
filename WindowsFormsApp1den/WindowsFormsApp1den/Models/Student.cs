using System;
using System.Collections.Generic;

namespace WindowsFormsApp1den
{
    internal class Student
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public List<int> Results { get; set; }

        public Student(string name, int course, string group, List<int> results)
        {
            Name = name;
            Course = course;
            Group = group;
            Results = results;
        }

        public int GetExcellentCount()
        {
            int count = 0;
            foreach (int result in Results)
            {
                if (result >= 90)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
