namespace Phonebook.Commands
{
    using System.Linq;

    using Phonebook.PhoneNumberParsers;
    using Phonebook.Printers;
    using Phonebook.Repositories;

    public class AddCommand : ICommand
    {
        private IPhonebookRepository data;
        private IPhoneNumberParser parser;
        private IPrinter printer;

        public AddCommand(IPhonebookRepository data, IPhoneNumberParser parser, IPrinter printer)
        {
            this.data = data;
            this.parser = parser;
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            string name = arguments[0];
            var phoneNumbers = arguments.Skip(1).ToList();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = this.parser.Parse(phoneNumbers[i]);
            }

            bool flag = this.data.AddPhone(name, phoneNumbers);

            if (flag)
            {
                this.printer.Print("Phone entry created");
            }
            else
            {
                this.printer.Print("Phone entry merged");
            }
        }
    }
}
