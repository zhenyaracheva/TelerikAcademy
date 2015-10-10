namespace Phonebook.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wintellect.PowerCollections;

    public class PhonebookRepositoryWithDictionary : IPhonebookRepository
    {
        private OrderedSet<PhoneEntry> sortedPhonebook = new OrderedSet<PhoneEntry>();
        private Dictionary<string, PhoneEntry> dict = new Dictionary<string, PhoneEntry>();
        private MultiDictionary<string, PhoneEntry> multidict = new MultiDictionary<string, PhoneEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            PhoneEntry entry;
            var isAddedNewContact = false;

            if (!this.dict.ContainsKey(name.ToLowerInvariant()))
            {
                this.dict[name.ToLowerInvariant()] = new PhoneEntry();
                this.dict[name.ToLowerInvariant()].Name = name;
                isAddedNewContact = true;
            }

            entry = this.dict[name.ToLowerInvariant()];
            this.sortedPhonebook.Add(entry);

            foreach (var num in phoneNumbers)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(phoneNumbers);
            return isAddedNewContact;
        }

        public int ChangePhone(string oldRecord, string newRecord)
        {
            var foundRecords = this.multidict[oldRecord].ToList();

            foreach (var entry in foundRecords)
            {
                entry.PhoneNumbers.Remove(oldRecord);
                this.multidict.Remove(oldRecord, entry);
                entry.PhoneNumbers.Add(newRecord); 
                this.multidict.Add(newRecord, entry);
            }

            return foundRecords.Count;
        }

        public PhoneEntry[] ListEntries(int startEntryIndex, int countEntries)
        {
            if (startEntryIndex < 0 || startEntryIndex + countEntries > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            PhoneEntry[] list = new PhoneEntry[countEntries];

            for (int i = startEntryIndex; i <= startEntryIndex + countEntries - 1; i++)
            {
                PhoneEntry entry = this.sortedPhonebook[i];
                list[i - startEntryIndex] = entry;
            }

            return list;
        }
    }
}
