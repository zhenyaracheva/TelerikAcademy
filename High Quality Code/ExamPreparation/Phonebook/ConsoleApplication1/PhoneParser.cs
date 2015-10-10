namespace Phonebook.PhoneNumberParsers
{
    using System.Text;

    public class PhoneParser : IPhoneNumberParser
    {
        private const string Code = "+359";

        public string Parse(string phoneNumber)
        {
            StringBuilder phoneNumberBuilder = new StringBuilder();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberBuilder.Append(ch);
                }
            }

            if (phoneNumberBuilder.Length >= 2 && phoneNumberBuilder[0] == '0' && phoneNumberBuilder[1] == '0')
            {
                phoneNumberBuilder.Remove(0, 1);
                phoneNumberBuilder[0] = '+';
            }

            while (phoneNumberBuilder.Length > 0 && phoneNumberBuilder[0] == '0')
            {
                phoneNumberBuilder.Remove(0, 1);
            }

            if (phoneNumberBuilder.Length > 0 && phoneNumberBuilder[0] != '+')
            {
                phoneNumberBuilder.Insert(0, Code);
            }

            return phoneNumberBuilder.ToString();
        }
    }
}
