namespace BankAccounts.Interfaces
{
    public interface ICompanyCustomer : ICustomer
    {
        string CompanyName { get; set; }
    }
}
