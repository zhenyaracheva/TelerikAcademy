namespace BankAccounts.Interfaces
{
    using System.Collections.Generic;

    public interface ICustomer
    {
        string IndividualNumber { get; set; }

        IList<IAccount> Accounts { get; }

        void AddAccount(IAccount account);

        void RemoveAccount(IAccount account);
    }
}
