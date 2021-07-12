using System;
namespace ch_19_prep
{
    public class Student
    {

        private static int _nextStudentId = 1;
        public readonly int studentId;

        public string Name { get; set; }
        public int NumberOfCredits { get; set; }
        public double Gpa { get; set; }

        public Student(string name, int sId, int numberOfCredits, double gpa)
        {
            Name = name;
            studentId = sId;
            NumberOfCredits = numberOfCredits;
            Gpa = gpa;
        }

        public Student(string name, int sId)
        {
            Name = name;
            studentId = sId;
            NumberOfCredits = 0;
            Gpa = 0.0;
        }

        public Student(string name)
        {
            Name = name;
            studentId = _nextStudentId;
            _nextStudentId++;
            NumberOfCredits = 0;
            Gpa = 0.0;
        }

        public override string ToString()
        {
            // In the book they do not use the this keyword
            // That is incorrect be sure to use the this keyword
            return this.Name + " (Credits: " + this.NumberOfCredits + ", GPA: " + this.Gpa + ")";
        }
    }
}
