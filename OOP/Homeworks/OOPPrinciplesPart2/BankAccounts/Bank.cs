namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    using BankAccounts.Interfaces;
    using System.Text;

    public class Bank : IBank
    {
        private string name;
        private ICollection<IAccount> accounts;

        public Bank(string initialName)
        {
            this.Name = initialName;
            this.accounts = new List<IAccount>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Bank  name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ICollection<IAccount> Accounts
        {
            get
            {
                return new HashSet<IAccount>(this.accounts);
            }
        }


        public void AddAccount(IAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Added account cannot be null.");
            }

            this.accounts.Add(account);
        }

        public void RemoveAccount(IAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Removed account cannot be null.");
            }

            this.accounts.Remove(account);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("Bank: {0}", this.Name));
            foreach (var account in this.Accounts)
            {
                output.AppendLine(account.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
