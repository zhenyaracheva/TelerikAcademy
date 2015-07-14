namespace RefactorExamPrintingTask
{
    using System;

    public class Printing
    {
        public static void Main()
        {
            long students = long.Parse(Console.ReadLine());
            long papers = long.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            long totalSheets = students * papers;
            decimal realmNeeded = (decimal)totalSheets / 500;
            decimal totalPrice = realmNeeded * price;

            Console.WriteLine("{0:F2}", totalPrice);
        }
    }
}
