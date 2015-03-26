namespace BankAccounts
{
    using System;

    using BankAccounts.Interfaces;

    public class CompanyCustomer : Customer, ICustomer, ICompanyCustomer
    {
        private string companyName;

        public CompanyCustomer(string individualNumber, string name)
            : base(individualNumber)
        {
            this.CompanyName = name;
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company name cannot be null or empty.");
                }

                if (value.Length <= 2)
                {
                    throw new ArgumentOutOfRangeException("Company name cannot be less than 2 symbols");
                }

                this.companyName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} --> {2}", this.GetType().Name, this.CompanyName, this.IndividualNumber);
        }
    }
}
