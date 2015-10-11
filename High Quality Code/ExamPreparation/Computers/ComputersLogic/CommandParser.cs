namespace ComputersLogic
{
    using System;

    public class CommandParser
    {
        private const string ExitCommandMessage = "Exit";
        private const string InvalidCommandMessage = "Invalid command!";

        public ICommand ParseCommand(string commandAsString)
        {
            var commnd = new Command();

            if (commandAsString.StartsWith(ExitCommandMessage))
            {
                commnd.Name = ExitCommandMessage;
            }
            else
            {
                var commandParameters = commandAsString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                commnd.Name = commandParameters[0];
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException(InvalidCommandMessage);
                    }
                }

                commnd.Argument = int.Parse(commandParameters[1]);
            }

            return commnd;
        }
    }
}
