namespace Phonebook
{
    using System;

    using Phonebook.CommandFactories;
    using Phonebook.Commands;
    using Phonebook.PhoneNumberParsers;
    using Phonebook.Printers;
    using Phonebook.Repositories;

    public class CommandFactory : ICommandFactory
    {
        private IPhonebookRepository data;
        private IPhoneNumberParser parser;
        private IPrinter printer;
        private AddCommand addCommand;
        private ChangePhone changePhone;
        private ListCommand listCommand;

        public CommandFactory(IPhonebookRepository data, IPhoneNumberParser parser, IPrinter printer)
        {
            this.data = data;
            this.parser = parser;
            this.printer = printer;
        }

        public ICommand CreateCommand(string command)
        {
            if (command == "AddPhone")
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new AddCommand(this.data, this.parser, this.printer);
                }

                return this.addCommand;
            }
            else if (command == "ChangePhone")
            {
                if (this.changePhone == null)
                {
                    this.changePhone = new ChangePhone(this.data, this.parser, this.printer);
                }

                return this.changePhone;
            }
            else if (command == "List")
            {
                if (this.listCommand == null)
                {
                    this.listCommand = new ListCommand(this.data, this.printer);
                }

                return this.listCommand;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid command!");
            }
        }
    }
}