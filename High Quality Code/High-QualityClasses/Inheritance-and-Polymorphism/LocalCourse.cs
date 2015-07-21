namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using InheritanceAndPolymorphism.Interfaces;

    public class LocalCourse : Course, ILocalCourse, ICourse
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, string lab)
            : this(courseName, teacherName, new List<string>(), lab)
        {
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.ValidateString(value, "Local course lab");
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Length -= 2;

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
