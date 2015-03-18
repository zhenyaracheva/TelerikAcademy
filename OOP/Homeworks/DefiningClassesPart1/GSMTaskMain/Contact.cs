namespace GSMTaskMain
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Contact
    {
        private string name;
        private string number;

        public Contact(string currentName, string number)
        {
            this.Name = currentName;
            this.Number = number;
        }

        public Contact(string currentNumber)
            : this(null, currentNumber)
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "Unknown";
                }

                this.name = value;
            }
        }

        public string Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (!this.ValidNumber(value))
                {
                    throw new ArgumentException("Ivalid phone number!");
                }

                this.number = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("{0}: {1}", this.Name, this.Number));

            return result.ToString();
        }

        private bool ValidNumber(string number)
        {
            if (!char.IsDigit(number[0]) && number[0] != '+')
            {
                return false;
            }

            for (int i = 1; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
