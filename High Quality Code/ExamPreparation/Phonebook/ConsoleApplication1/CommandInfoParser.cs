namespace Phonebook
{
    using System;

    using Phonebook.Contracts;

    public class CommandInfoParser : ICommandInfoParser
    {
        public ICommandInfo Parse(string data)
        {
            int firstOpenParantesis = data.IndexOf('(');

            if (firstOpenParantesis == -1 || !data.EndsWith(")"))
            {
                throw new ArgumentOutOfRangeException("Invalid input!");
            }

            var commandInfo = new CommandInfo();
            commandInfo.CommandName = data.Substring(0, firstOpenParantesis);

            string commandArgumentsAsString = data.Substring(firstOpenParantesis + 1, data.Length - firstOpenParantesis - 2);
            commandInfo.CommandArguments = commandArgumentsAsString.Split(',');

            for (int j = 0; j < commandInfo.CommandArguments.Length; j++)
            {
                commandInfo.CommandArguments[j] = commandInfo.CommandArguments[j].Trim();
            }

            return commandInfo;
        }
    }
}
