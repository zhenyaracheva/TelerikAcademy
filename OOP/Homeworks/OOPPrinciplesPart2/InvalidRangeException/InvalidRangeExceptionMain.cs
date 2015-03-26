namespace RangeException
{
    using System;
    using System.Globalization;

    public class InvalidRangeExceptionMain
    {
        public static void Main(string[] args)
        {
            Console.Write("Please, enter an integer: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 100)
            {
                throw new InvalidRangeException<int>("Number is out of range [1....100]", 1, 100);
            }
            else
            {
                Console.WriteLine("Number is not out of range [1...100]");
            }

            Console.WriteLine();
            Console.Write("Please, enter a date in format dd/MM/yyyy: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(2013, 12, 31);

            if (date < start || date > end)
            {
                throw new InvalidRangeException<DateTime>("Date must be in range [1.1.1980] - [31.12.2013]", start, end);
            }
            else
            {
                Console.WriteLine("Date is not out of range[1.1.1980] - [31.12.2013]");
            }
        }
    }
}
