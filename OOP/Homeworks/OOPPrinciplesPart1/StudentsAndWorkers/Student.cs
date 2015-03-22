namespace StudentsAndWorkers
{
    using System;

    using StudentsAndWorkers.Interfaces;

    public class Student : Human, IStudent, IHuman
    {
        private int grade;

        public Student(string initialFirstName, string initialLastName, int initialGrade)
            : base(initialFirstName, initialLastName)
        {
            this.Grade = initialGrade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Student grade cannot be less or equal to 0.");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
