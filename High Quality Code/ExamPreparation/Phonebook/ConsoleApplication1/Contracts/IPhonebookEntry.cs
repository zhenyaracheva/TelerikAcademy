namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public interface IPhonebookEntry 
    {
        ISet<string> PhoneNumbers { get; set; }

        string Name { get; set; }
    }
}
