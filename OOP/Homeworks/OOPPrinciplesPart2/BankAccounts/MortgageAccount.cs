namespace BankAccounts
{
    using System;

    using BankAccounts.Interfaces;

    public class MortgageAccount : Account, IMortgageAccount, IAccount, IDepositable
    {
        private const int MinInterestIndividualCuttomer = 6;
        private const int MinInterestCompanyCustomer = 12;

        public MortgageAccount(Customer initialCustomer, decimal startBalance, decimal initialInterestRate)
            : base(initialCustomer, startBalance, initialInterestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months < MortgageAccount.MinInterestIndividualCuttomer)
                {
                    throw new ArgumentException(string.Format("No interest if period is less than {0} months.", MortgageAccount.MinInterestIndividualCuttomer));
                }

                if (this.Customer is CompanyCustomer)
                {
                    if (months < MortgageAccount.MinInterestCompanyCustomer)
                    {
                        return base.CalculateInterestAmount(months) / 2;
                    }
                }
            }

            return base.CalculateInterestAmount(months);
        }
    }
}
