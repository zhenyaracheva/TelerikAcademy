namespace Phonebook.CommandFactories
{
    using Phonebook.Commands;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string command);
    }
}
