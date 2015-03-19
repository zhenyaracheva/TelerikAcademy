namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Student
    {
        private const int MinMark = 2;
        private const int MaxMark = 6;
        private static List<char> allowedSymbolsInPhoneNumber = new List<char>() { '/', '(', ')', ' ', '-' };

        private string firstName;
        private string lastName;
        private string fn;
        private string phoneNumber;
        private string email;
        private List<int> marks;
        private int groupNumber;
        private Group group;

        public Student(string initialFirstName, string initialLastName, string initialFN, int initialGroupNumber)
        {
            this.FirstName = initialFirstName;
            this.LastName = initialLastName;
            this.FN = initialFN;
            this.Marks = new List<int>();
            this.GroupNumber = initialGroupNumber;
        }

        public Student(string initialFirstName, string initialLastName, string initialFN, string initialPhoneNumber, string initialEmail, int initialGroupNumber)
            : this(initialFirstName, initialLastName, initialFN, initialGroupNumber)
        {
            this.PhoneNumber = initialPhoneNumber;
            this.Email = initialEmail;
        }

        public Student(string initialFirstName, string initialLastName, string initialFN, Group initialGroup)
        {
            this.FirstName = initialFirstName;
            this.LastName = initialLastName;
            this.FN = initialFN;
            this.Group = initialGroup;
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
                    throw new ArgumentNullException("Last name cannot be null or empty=");
                }

                this.lastName = value;
            }
        }

        public string FN
        {
            get
            {
                return this.fn;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FN cannot be null or empty.");
                }

                if (value.Length != 6)
                {
                    throw new ArgumentException("FN cannot have lenght different than 6 digits.");
                }

                this.fn = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Phone number cannot be null or empty.");
                }

                if (!this.ValidNumber(value))
                {
                    throw new ArgumentOutOfRangeException("Invalid phone number.");
                }

                this.phoneNumber = value;
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
                    throw new ArgumentNullException("E-mail cannot be null or empty.");
                }

                if (!this.ValidEmail(value))
                {
                    throw new ArgumentException("Invalid e-mail.");
                }

                this.email = value;
            }
        }

        public IList<int> Marks
        {
            get
            {
                return this.marks;
            }

            private set
            {
                this.marks = new List<int>();
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Group cannot be negativeor 0.");
                }

                this.groupNumber = value;
            }
        }

        public Group Group
        {
            get
            {
                return this.group;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Group cannot be null");
                }

                this.group = value;
            }
        }

        public void AddStudentMark(int mark)
        {
            this.Marks.Add(mark);
        }

        private bool ValidEmail(string text)
        {
            string regexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";
            var matches = Regex.Matches(text, regexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (matches.Count != 0)
            {
                return true;
            }

            return false;
        }

        private bool ValidNumber(string number)
        {
            if (!char.IsDigit(number[0]) && number[0] != '+' && number[0] != '(')
            {
                return false;
            }

            for (int i = 1; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]) && !Student.allowedSymbolsInPhoneNumber.Contains(number[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
