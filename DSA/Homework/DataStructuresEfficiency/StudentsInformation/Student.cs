namespace StudentsInformation
{
    using System;

    public class Student : IComparable
    {
        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Course { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public int CompareTo(object obj)
        {
            var student = obj as Student;

            return this.ToString().CompareTo(student.ToString());
        }
    }
}
