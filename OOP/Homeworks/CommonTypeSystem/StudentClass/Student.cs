namespace StudentClass
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        #region Fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string phone;
        private string email;
        private int course;
        private Specialty speciality;
        private University university;
        private Faculty faculty;
        #endregion
        
        #region Constructors
        public Student(string initialFirsttName, string initialMiddleName, string initialLastName, string initialSSN,
            string permanetAddress, string phoneNumber, string emailAddress, int currentCourse, Specialty initialSpeciality,
            University initialUniversity, Faculty initialFaculty)
        {
            this.FirstName = initialFirsttName;
            this.MiddleName = initialMiddleName;
            this.LastName = initialLastName;
            this.SSN = initialSSN;
            this.Address = permanetAddress;
            this.PhoneNumber = phoneNumber;
            this.Email = emailAddress;
            this.Course = currentCourse;
            this.Specialty = initialSpeciality;
            this.University = initialUniversity;
            this.Faculty = initialFaculty;
        }
        #endregion
        
        #region Proparties
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
                    throw new ArgumentNullException("Student first name cannot be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student middle name cannot be null or empty.");
                }

                this.middleName = value;
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
                    throw new ArgumentNullException("Student last name cannot be null or empty.");
                }

                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student ssn cannot be null or empty.");
                }

                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student address cannot be null or empty.");
                }

                this.address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student phone number cannot be null or empty.");
                }

                this.phone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student e-mail cannot be null or empty.");
                }

                this.email = value;
            }
        }

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                if (value > 4 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Course  is out of range.");
                }

                this.course = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.speciality;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Student specialty cannot be null.");
                }

                this.speciality = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("University cannot be null or empty.");
                }

                this.university = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Faculty cannot be null or empty.");
                }

                this.faculty = value;
            }
        }
        #endregion
        
        #region Methods
        public override bool Equals(object obj)
        {
            var student = obj as Student;

            if (student == null)
            {
                return false;
            }

            return this.FirstName.Equals(student.FirstName) &&
                   this.MiddleName.Equals(student.FirstName) &&
                   this.LastName.Equals(student.LastName) &&
                   this.SSN.Equals(student.SSN) &&
                   this.Email.Equals(student.Email);
        }

        public override int GetHashCode()
        {

            return this.FirstName.GetHashCode() * this.MiddleName.GetHashCode() * this.LastName.GetHashCode()
                           * (this.SSN.GetHashCode() * this.Email.GetHashCode());
        }

        public override string ToString()
        {
            string fullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            return string.Format("{0} - {1} - {2}", fullName, this.SSN, this.University);
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.PhoneNumber,
                               this.Email, this.Course, this.Specialty, this.University, this.Faculty);
        }

        public int CompareTo(Student student)
        {
            string firstStudentName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string secondStudentName = student.FirstName + " " + student.MiddleName + " " + student.LastName;

            int result = firstStudentName.CompareTo(secondStudentName);

            if (result == 0)
            {
                return this.SSN.CompareTo(student.SSN);
            }

            return result;
        }
        #endregion
    }
}
