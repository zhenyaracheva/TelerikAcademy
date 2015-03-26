namespace BankAccounts.Interfaces
{
    public interface IAccount : IDepositable
    {
        Customer Customer { get; }

        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        decimal CalculateInterestAmount(int months);

        // void DepositMoney(decimal amount);
    }
}
