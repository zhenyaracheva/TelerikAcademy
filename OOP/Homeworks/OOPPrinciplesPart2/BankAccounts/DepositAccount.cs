namespace BankAccounts
{
    using System;

    using BankAccounts.Interfaces;
    using System.Text;

    public class DepositAccount : Account, IAccount, IDepositAccount, IWithdrawable, IDepositable
    {
        private const int MaxInterestValue = 1000;
        private const int MinInterestValue = 0;

        public DepositAccount(Customer initialCustomer, decimal startBalance, decimal initialInterestRate)
            : base(initialCustomer, startBalance, initialInterestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance < DepositAccount.MaxInterestValue && this.Balance >= DepositAccount.MinInterestValue)
            {
                throw new ArgumentException(string.Format("Cannot calculate interest with positive balance les than {0}.", DepositAccount.MaxInterestValue));
            }

            return base.CalculateInterestAmount(months);
        }

        public void WithdrawAmount(decimal amount)
        {
            if (this.Balance < amount)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be bigger than balance");
            }

            this.Balance -= amount;
        }
    }
}
