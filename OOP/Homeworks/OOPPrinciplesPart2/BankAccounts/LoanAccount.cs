namespace BankAccounts
{
    using System;

    using BankAccounts.Interfaces;

    public class LoanAccount : Account, ILoanAccount, IAccount, IDepositable
    {
        private const int MinInterestMonthsInvisidualCustomer = 3;
        private const int MinInterestMonthsCompanyCustomer = 2;

        public LoanAccount(Customer initialCustomer, decimal startBalance, decimal initialInterestRate)
            : base(initialCustomer, startBalance, initialInterestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months <= LoanAccount.MinInterestMonthsInvisidualCustomer)
                {
                    throw new ArgumentException(string.Format("Cannot calculate interest if period is less or equal to {0}", LoanAccount.MinInterestMonthsInvisidualCustomer));
                }
            }
            else if (this.Customer is CompanyCustomer)
            {
                if (months <= LoanAccount.MinInterestMonthsCompanyCustomer)
                {
                    throw new ArgumentException(string.Format("Cannot calculate interest if perid is less or equal to {0}", LoanAccount.MinInterestMonthsCompanyCustomer));
                }
            }

            return base.CalculateInterestAmount(months);
        }
    }
}
