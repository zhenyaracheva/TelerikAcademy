namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string initialName)
        {
            this.Name = initialName;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher name cannot be null or empry.");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be null.");
            }

            this.courses.Add(course);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(string.Format("Teacher: Name={0}", this.Name));

            if (this.courses.Count != 0)
            {
                string coursesAsString = string.Join(", ", this.courses.Select(c => c.Name));
                result.Append(string.Format("; Courses=[{0}]", coursesAsString));
            }

            return result.ToString();
        }
    }
}
