namespace Phonebook.Commands
{
    using System;
    using System.Collections.Generic;

    using Phonebook.Printers;
    using Phonebook.Repositories;

    public class ListCommand : ICommand
    {
        private IPhonebookRepository data;
        private IPrinter printer;

        public ListCommand(IPhonebookRepository data, IPrinter printer)
        {
            this.data = data;
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            {
                IEnumerable<PhoneEntry> entries = this.data.ListEntries(int.Parse(arguments[0]), int.Parse(arguments[1]));
                foreach (var entry in entries)
                {
                    this.printer.Print(entry.ToString());
                }
            }
        }
    }
}
