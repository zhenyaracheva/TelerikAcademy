namespace StudentsAndWorkers
{
    using System;

    using StudentsAndWorkers.Interfaces;

    public abstract class Human : IHuman
    {
        private string firstName;
        private string lastName;

        public Human(string initialFirstName, string initialLastName)
        {
            this.FirstName = initialFirstName;
            this.LastName = initialLastName;
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

                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("First name cannot have less than 2 symbols.");
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

                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("LAst name cannot have less than 2 symbols.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
