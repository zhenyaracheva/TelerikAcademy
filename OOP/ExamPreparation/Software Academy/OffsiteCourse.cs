namespace SoftwareAcademy
{
    using System;
    using System.Text;

    public class OffsiteCourse : Course, IOffsiteCourse, ICourse
    {
        private string town;

        public OffsiteCourse(string initialName, ITeacher initialTeacher, string initialTown)
            : base(initialName, initialTeacher)
        {
            this.Town = initialTown;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town cannot be null or empty.");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format("; Town={0}", this.Town));

            return result.ToString();
        }
    }
}
