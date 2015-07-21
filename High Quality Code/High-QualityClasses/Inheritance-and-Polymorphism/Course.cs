namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using InheritanceAndPolymorphism.Interfaces;

    public abstract class Course : ICourse
    {
        private const int MinNameLength = 2;

        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.teacherName = teacherName;
            this.students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.ValidateString(value, "Course name");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.ValidateString(value, "Teacher name");
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students.OrderBy(x => x).ToList();
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Course students cannot be null!");
                }

                this.students = value;
            }
        }

        public void AddStudent(string student)
        {
            this.ValidateString(student, "Added student name");

            this.students.Add(student);
        }

        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name + " { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            result.Append(" }");
            return result.ToString();
        }

        protected void ValidateString(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(name + " lenght cannot be null or empty!");
            }
            else if (value.Length < Course.MinNameLength)
            {
                throw new ArgumentException(name + " lenght cannot be less or equal to" + Course.MinNameLength + " !");
            }
        }
    }
}
