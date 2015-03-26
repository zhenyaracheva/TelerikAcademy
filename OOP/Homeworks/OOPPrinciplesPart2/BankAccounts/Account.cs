namespace BankAccounts
{
    using System;

    using BankAccounts.Interfaces;
    using System.Text;

    public abstract class Account : IAccount, IDepositable
    {
        private Customer customer;
        private decimal balance;

        public Account(Customer initialCustomer, decimal startBalance, decimal initialInterestRate)
        {
            this.Customer = initialCustomer;
            this.Balance = startBalance;
            this.InterestRate = initialInterestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be null.");
                }

                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                if (value < 0.00m)
                {
                    throw new ArgumentOutOfRangeException("Balance cannot be negative.");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate { get; set; }

        public virtual decimal CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Months cannot be less than 0.");
            }

            return this.InterestRate * months;
        }

        public void DepositMoney(decimal amount)
        {
            if (amount <= 0.00m)
            {
                throw new ArgumentOutOfRangeException("Deposit cannot be negative.");
            }

            this.Balance += amount;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("Account: {0}", this.GetType().Name));
            output.AppendLine(string.Format("   {0}", this.Customer.ToString()));
            output.AppendLine(string.Format("   Balance: {0}", this.Balance));
            output.Append(string.Format("   Interest rate: {0}%", this.InterestRate));

            return output.ToString();
        }
    }
}
