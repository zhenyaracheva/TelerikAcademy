namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhoneEntry : IPhonebookEntry, IComparable<PhoneEntry>
    {
        private ISet<string> phoneNumbers;

        public PhoneEntry()
        {
            this.phoneNumbers = new SortedSet<string>();
        }

        public ISet<string> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            set
            {
                this.phoneNumbers = value;
            }
        }
      
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');
            sb.Append(this.Name);
            sb.Append(": ");
            sb.Append(string.Join(", ", this.PhoneNumbers));
            /// bool flag = true;
            /// 
            /// foreach (var phone in this.Strings)
            /// {
            ///     if (flag)
            ///     {
            ///         sb.Append(": ");
            ///         flag = false;
            ///     }
            ///     else
            ///     {
            ///         sb.Append(", ");
            ///     }
            /// 
            ///     sb.Append(phone);
            /// }

            sb.Append(']');

            return sb.ToString();
        }

        public int CompareTo(PhoneEntry other)
        {
            return this.Name.ToLowerInvariant().CompareTo(other.Name.ToLowerInvariant());
        }
    }
}
