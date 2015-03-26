namespace BankAccounts
{
    using System;

    using BankAccounts.Interfaces;
    using System.Text;

    public class IndividualCustomer : Customer, ICustomer, IIndividualCustomer
    {
        private string firstName;
        private string lastName;

        public IndividualCustomer(string individualNumber, string initialFirstName, string initialLastName)
            : base(individualNumber)
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

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Customer first name cannot be null or empty.");
                }

                if (value.Length <= 2)
                {
                    throw new ArgumentOutOfRangeException("First name cannot be less than 2 symbols");
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
                    throw new ArgumentNullException("Customer last name cannot be null or empty.");
                }

                if (value.Length <= 2)
                {
                    throw new ArgumentOutOfRangeException("First last cannot be less than 2 symbols");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2} --> {3}", this.GetType().Name, this.FirstName, this.LastName, this.IndividualNumber);

        }
    }
}
