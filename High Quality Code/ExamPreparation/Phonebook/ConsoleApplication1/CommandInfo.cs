namespace Phonebook
{
    public class CommandInfo : ICommandInfo
    {
        public string CommandName { get; set; }

        public string[] CommandArguments { get; set; }
    }
}
