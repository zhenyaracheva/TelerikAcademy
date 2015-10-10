namespace School
{
    using System;

    public class Student
    {
        private string name;
        private int schoolId;
        private School school;

        public Student(string name, School school)
        {
            this.Name = name;
            this.School = school;
            this.SchoolId = this.School.GetStudentSchoolId();
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
                    throw new ArgumentNullException("Student name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int SchoolId
        {
            get
            {
                return this.schoolId;
            }

            set
            {
                this.schoolId = value;
            }
        }

        public School School
        {
            get
            {
                return this.school;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Student school cannot be null!");
                }

                this.school = value;
            }
        }

        public override string ToString()
        {
            return this.Name + ": " + this.SchoolId;
        }
    }
}
