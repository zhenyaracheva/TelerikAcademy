namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using InheritanceAndPolymorphism.Interfaces;

    internal class OffsiteCourse : Course, IOffsiteCourse, ICourse
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, string town)
            : this(courseName, teacherName, new List<string>(), town)
        {
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                this.ValidateString(value, "Offsite course town");
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Length -= 2;

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
