namespace BankAccounts.Interfaces
{
    public interface IDepositAccount : IAccount, IDepositable, IWithdrawable
    {
        void WithdrawAmount(decimal amount);
    }
}
