namespace Phonebook.Commands
{
    public interface ICommand
    {
        void Execute(string[] arguments);
    }
}
