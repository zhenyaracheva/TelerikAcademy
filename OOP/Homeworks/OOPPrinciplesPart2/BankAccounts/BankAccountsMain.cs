namespace BankAccounts
{
    using System;

    public class BankAccountsMain
    {
        public static void Main()
        {
            Bank bank = new Bank("New Bank");
            bank.AddAccount(new DepositAccount(new IndividualCustomer("0000000000", "Stela", "Artoanova"), 2000.00m, 0.05m));
            bank.AddAccount(new LoanAccount(new CompanyCustomer("1111111111", "FunnyCompany"), 2000000.00m, 15.75m));
            bank.AddAccount(new MortgageAccount(new IndividualCustomer("2222222222", "Pirina", "Shumenska"), 100m, 0.75m));
            bank.AddAccount(new DepositAccount(new CompanyCustomer("3333333333", "SmileCompany"), 48565245.00m, 50.00m));
            bank.AddAccount(new LoanAccount(new IndividualCustomer("4444444444", "Kamen", "Zagorkov"), 986.00m, 20.00m));
            bank.AddAccount(new MortgageAccount(new CompanyCustomer("555555555555", "JoyCompany"), 5000000, 25.75m));

            Console.WriteLine(bank.ToString());
        }
    }
}
