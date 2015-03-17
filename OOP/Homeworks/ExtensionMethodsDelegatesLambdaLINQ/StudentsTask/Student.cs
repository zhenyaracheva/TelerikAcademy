// Problem 3. First before last
   
// Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
// Use LINQ query operators.
// Problem 4. Age range
   
// Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
// Problem 5. Order students
   
// Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
// Rewrite the same with LINQ.
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
