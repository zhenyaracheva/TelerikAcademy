namespace Phonebook
{
    public interface ICommandInfo
    {
        string CommandName { get; set; }

        string[] CommandArguments { get; set; }
    }
}
