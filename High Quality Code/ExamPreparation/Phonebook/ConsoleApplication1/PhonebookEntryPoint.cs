namespace Phonebook.Repositories
{
    using System;

    using Phonebook.CommandFactories;
    using Phonebook.PhoneNumberParsers;
    using Phonebook.Printers;

    public class PhonebookEntryPoint
    {
        public static void Main()
        {
            IPhonebookRepository data = new PhonebookRepositoryWithDictionary();
            IPhoneNumberParser parser = new PhoneParser();
            IPrinter printer = new Printer();
            ICommandFactory commandFactory = new CommandFactory(data, parser, printer);
            CommandInfoParser commandInfoParser = new CommandInfoParser();

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "End" || userInput == null)
                {
                    break;
                }

                var commandInfo = commandInfoParser.Parse(userInput);

                try
                {
                    var command = commandFactory.CreateCommand(commandInfo.CommandName);
                    command.Execute(commandInfo.CommandArguments);
                }
                catch (ArgumentOutOfRangeException)
                {
                    printer.Print("Invalid range");
                }
            }

            Console.Write(printer.GetAllText());
        }
    }
}
