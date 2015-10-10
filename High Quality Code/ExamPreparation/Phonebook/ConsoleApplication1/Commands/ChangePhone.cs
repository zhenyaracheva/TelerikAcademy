namespace Phonebook.Commands
{
    using Phonebook.PhoneNumberParsers;
    using Phonebook.Printers;
    using Phonebook.Repositories;

    public class ChangePhone : ICommand
    {
        private IPhonebookRepository data;
        private IPhoneNumberParser parser;
        private IPrinter printer;

        public ChangePhone(IPhonebookRepository data, IPhoneNumberParser parser, IPrinter printer)
        {
            this.data = data;
            this.parser = parser;
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            this.printer.Print(this.data.ChangePhone(this.parser.Parse(arguments[0]), this.parser.Parse(arguments[1])) + " numbers changed");
        }
    }
}
