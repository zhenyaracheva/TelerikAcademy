namespace SchoolClasses
{
    using System;
    using System.Text;

    using SchoolClasses.Interfaces;

    public class Student : People, IStudent, IPeople
    {
        private const int MinStudentClassNumber = 1;
        private const int MaxStudentClassNumber = 200;

        private int classNumber;

        public Student(string name, int initialClassNumber)
            : base(name)
        {
            this.ClassNumber = initialClassNumber;
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                if (value < Student.MinStudentClassNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student number cannot be less than {0}", Student.MinStudentClassNumber));
                }

                if (value > Student.MaxStudentClassNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student number cannot be bigger than {0}", Student.MaxStudentClassNumber));
                }

                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("Student {0}", base.ToString()));
            output.Append(string.Format("Class number: {0}", this.ClassNumber));

            return output.ToString();
        }
    }
}
