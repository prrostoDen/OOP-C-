using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1den
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameTb.Text.Trim();
            int course = int.Parse(courseTb.Text.Trim());
            string group = groupTb.Text.Trim();
            List<int> results = new List<int>();
            results.Add(int.Parse(result1Tb.Text.Trim()));
            results.Add(int.Parse(result2Tb.Text.Trim()));
            results.Add(int.Parse(result3Tb.Text.Trim()));
            results.Add(int.Parse(result4Tb.Text.Trim()));

            Student student = new Student(name, course, group, results);
            students.Add(student);

            nameTb.Clear();
            courseTb.Clear();
            groupTb.Clear();
            result1Tb.Clear();
            result2Tb.Clear();
            result3Tb.Clear();
            result4Tb.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("students.txt");
            foreach (Student student in students)
            {
                string resultsData = string.Join(" ", student.Results);
                writer.WriteLine($"{student.Name}, {student.Course}, {student.Group}, {resultsData}");
            }
            writer.Close();

            MessageBox.Show("Student data saved to file.");
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> excellentCounts = new Dictionary<string, int>();
            foreach (Student student in students)
            {
                if (excellentCounts.ContainsKey(student.Group))
                {
                    excellentCounts[student.Group] += student.GetExcellentCount();
                }
                else
                {
                    excellentCounts[student.Group] = student.GetExcellentCount();
                }
            }

            listBox1.Items.Clear();
            foreach (var group in excellentCounts.Keys)
            {
                listBox1.Items.Add($"{group}: {excellentCounts[group]}");
            }
        }
    }
}
