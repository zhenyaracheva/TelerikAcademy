namespace SoftwareAcademy
{
    using System;
    using System.Text;

    public class LocalCourse : Course, ILocalCourse, ICourse
    {
        private string lab;

        public LocalCourse(string initialName, ITeacher initialTeacher, string initialLab)
            : base(initialName, initialTeacher)
        {
            this.Lab = initialLab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lab cannot be null or empty.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format("; Lab={0}", this.Lab));

            return result.ToString();
        }
    }
}
