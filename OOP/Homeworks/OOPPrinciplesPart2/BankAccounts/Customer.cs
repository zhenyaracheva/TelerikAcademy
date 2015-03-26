namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    using BankAccounts.Interfaces;
    using System.Text;

    public abstract class Customer : ICustomer
    {
        private string individualNumber;
        private IList<IAccount> accounts;
        
        public Customer(string initialIndividualNumber)
        {
            this.IndividualNumber = initialIndividualNumber;
            this.accounts = new List<IAccount>();
        }

        public string IndividualNumber
        {
            get
            {
                return this.individualNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Individual number cannot be null or empty.");
                }

                if (!this.CheckValidNumber(value))
                {
                    throw new ArgumentOutOfRangeException("Individual number can contains only digits.");
                }

                this.individualNumber = value;
            }
        }

        public IList<IAccount> Accounts
        {
            get
            {
                return new List<IAccount>(this.accounts);
            }
        }

        public void AddAccount(IAccount account)
        {
            this.accounts.Add(account);
        }

        public void RemoveAccount(IAccount account)
        {
            this.accounts.Remove(account);
        }


        private bool CheckValidNumber(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
