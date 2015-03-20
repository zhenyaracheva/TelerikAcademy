namespace ExtensionMethods.Extensions
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            if (index > sb.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            if (index + length > sb.Length)
            {
                throw new ArgumentOutOfRangeException("Lenght is out of range.");
            }

            var result = new StringBuilder();

            for (int i = index; i < index + length; i++)
            {
                result.Append(sb[i]);
            }

            return result;
        }
    }
}
