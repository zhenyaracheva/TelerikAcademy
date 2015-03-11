namespace GSMTaskMain
{
    using System;
    using System.Text;

    public class Owner
    {
        private string firstName;
        private string lastName;
        private int age;

        public Owner(string firstName, string lastName, int age)
            : this(firstName, lastName)
        {
            this.Age = age;
        }

        public Owner(string firstName, string lastName)
            : this(firstName)
        {
            this.LastName = lastName;
        }

        public Owner(string firstName)
        {
            this.firstName = firstName;
        }

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
                    throw new ArgumentNullException("Owner first name cannot be null or empty!");
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
                    throw new ArgumentNullException("Owner last name cannot be null or empty!");
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
                if (value < 3)
                {
                    throw new ArgumentException("Owner age cannot be smaller than 3!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- Owner first name: {0}", this.FirstName));

            if (this.LastName != null)
            {
                result.AppendLine(string.Format("- Owner last name: {0}", this.LastName));
            }

            if (this.Age != null)
            {
                result.AppendLine(string.Format("- Owner age: {0}", this.Age));
            }

            return result.ToString().Trim();
        }
    }
}
