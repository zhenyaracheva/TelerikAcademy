namespace Methods
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class Student
    {
        private const int MinStringValue = 2;
        private const int MinOtherInfoLength = 10;
        private const string DatePattern = "dd.MM.yyyy";

        private string firstName;
        private string lastName;
        private string otherInfo;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Student first name cannot be null or empty!");
                }
                else if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Student first name length cannot be less than 2 symbols!");
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

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Student last name cannot be null or empty!");
                }
                else if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Student last name length cannot be less than 2 symbols!");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Student otherInfo cannot be null or empty!");
                }
                else if (value.Length < Student.MinOtherInfoLength)
                {
                    throw new ArgumentOutOfRangeException("Student last name length cannot be less than " + Student.MinOtherInfoLength + " symbols!");
                }
                else if (!this.ContainsDate(value))
                {
                    throw new ArgumentException("OtherInfo must contains date in format: " + Student.DatePattern);
                }

                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            var firstDateAsString = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            var secondDateAsString = other.OtherInfo.Substring(other.OtherInfo.Length - 10);

            DateTime firstDate = this.ParseDate(firstDateAsString);
            DateTime secondDate = this.ParseDate(secondDateAsString);

            if (firstDate.Year > secondDate.Year)
            {
                return true;
            }
            else if (firstDate.Month > secondDate.Month)
            {
                return true;
            }
            else if (firstDate.Day > secondDate.Day)
            {
                return true;
            }

            return false;
        }

        private DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, Student.DatePattern, CultureInfo.InvariantCulture);
        }

        private bool ContainsDate(string input)
        {
            var date = input.Substring(input.Length - Student.MinOtherInfoLength);
            Regex regex = new Regex(@"(\d+)[.](\d+)[.](\d+)");
            Match match = regex.Match(input);

            return match.Success;
        }
    }
}
