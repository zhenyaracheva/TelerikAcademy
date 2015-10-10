namespace Phonebook.Contracts
{
    public interface ICommandInfoParser
    {
        ICommandInfo Parse(string data);
    }
}
