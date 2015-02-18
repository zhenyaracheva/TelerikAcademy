//Problem 16. Date difference

//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
//Example:

//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2006
//Distance: 4 days

using System;

class PrintDateDifference
{
    static void Main()
    {
        Console.Write("Please, enter first date(format day.month.year): ");
        string[] first = Console.ReadLine().Split(new[] { '.', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        DateTime firstDate = new DateTime(int.Parse(first[2]), int.Parse(first[1]), int.Parse(first[0]));

        Console.Write("Please, enter second date(format day.month.year): ");
        string[] second = Console.ReadLine().Split(new[] { '.', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        DateTime secondDate = new DateTime(int.Parse(second[2]), int.Parse(second[1]), int.Parse(second[0]));

        Console.WriteLine("Days between them: {0}", (firstDate > secondDate ? (firstDate - secondDate).TotalDays : 
            (secondDate - firstDate).TotalDays));
    }
}

