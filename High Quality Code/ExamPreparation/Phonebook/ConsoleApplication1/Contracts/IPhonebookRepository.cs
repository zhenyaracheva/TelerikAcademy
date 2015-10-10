namespace Phonebook.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A system designed to host a phonebook holds phonebook entries (name and list of phone numbers). 
    /// The interface allows adding to the phonebook, changing phones and listing the entries with paging
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds a new entry to the phone book.The names in the phonebook are unique (duplicates are not accepted) and 
        /// case-insensitive. Adding phones for same name always performs merging: only the non-repeating canonical phones 
        /// enter in the list of phones. 
        /// </summary>
        /// <param name="name">Name that holds phone numbers</param>
        /// <param name="phoneNumbers">Set of phone numbers</param>
        /// <returns></returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes the specified old phone number in all phonebook entries with a new one. The command prints “X numbers changed” 
        /// as a result, where X is the number of the changed old phone numbers in the system. 
        /// </summary>
        /// <param name="oldPhoneNumber">Value that needs to be changed</param>
        /// <param name="newPhoneNumber">Phone number that needs to be set</param>
        /// <returns></returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Lists the phonebook entries with paging. The page is specified by start index (zero-based) and count in the 
        /// phonebook assuming that the entries are sorted by name (case-insensitive). 
        /// </summary>
        /// <param name="startIndex">Start searching index</param>
        /// <param name="count">Records to be listed</param>
        /// <returns></returns>
        PhoneEntry[] ListEntries(int startIndex, int count);
    }
}
