namespace BankAccounts.Interfaces
{
    public interface IIndividualCustomer : ICustomer
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
