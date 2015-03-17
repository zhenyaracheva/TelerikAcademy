namespace StudentsTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public const int MinAgeOfStudent = 6;

        private string firstName;
        private string lastName;
        private int age;

        public Student(string initialFirstName, string initialLastName, int initialAge)
        {
            this.FirstName = initialFirstName;
            this.LastName = initialLastName;
            this.Age = initialAge;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty.");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < Student.MinAgeOfStudent)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student cannot be yonger than {0}", Student.MinAgeOfStudent));
                }

                this.age = value;
            }
        }
    }
}
