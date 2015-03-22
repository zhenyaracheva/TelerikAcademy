namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SchoolClasses.Interfaces;

    public class Class : IClass
    {
        private string identifier;
        private ICollection<ITeacher> teachers;
        private ICollection<IStudent> students;

        public Class(string initialIdentifier)
        {
            this.Identifier = initialIdentifier;
            this.teachers = new List<ITeacher>();
            this.students = new List<IStudent>();
        }

        public ICollection<ITeacher> Teachers
        {
            get
            {
                return new List<ITeacher>(this.teachers);
            }
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Class identifier cannot be null or empty.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Class identifier cannot have less than 2 symbols.");
                }

                this.identifier = value;
            }
        }

        public ICollection<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }
        }

        public void AddTeacher(ITeacher teacher)
        {
            if (this.teachers.Contains(teacher))
            {
                throw new ArgumentException(string.Format("Class already contains teacher {0}.", teacher.Name));
            }

            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(ITeacher teacher)
        {
            this.teachers.Remove(teacher);
        }

        public void AddStudent(IStudent student)
        {
            if (this.students.Contains(student))
            {
                throw new ArgumentException(string.Format("Class already contains student {0}.", student.Name));
            }

            this.students.Add(student);
        }

        public void RemoveStudent(IStudent student)
        {
            this.students.Remove(student);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("{0}: ", this.Identifier));
            
            if (this.teachers.Count != 1)
            {
                output.Append("   *Teachers: ");

                if (this.teachers.Count != 0)
                {
                    string teachersAsString = string.Join(", ", this.teachers.Select(t => t.Name));
                    output.AppendLine(teachersAsString);
                }
                else
                {
                    output.AppendLine("No teachers");
                }
            }
            else
            {
                output.AppendLine(string.Format("   *Teacher: {0}", this.teachers.First().Name));
            }

            if (this.students.Count != 1)
            {
                output.Append("   *Students: ");

                if (this.teachers.Count != 0)
                {
                    string studentsAsString = string.Join(", ", this.students.Select(t => t.Name));
                    output.AppendLine(studentsAsString);
                }
                else
                {
                    output.AppendLine("No students");
                }
            }
            else
            {
                output.AppendLine(string.Format("Student: {0}", this.students.First().Name));
            }

            return output.ToString().Trim();
        }
    }
}
