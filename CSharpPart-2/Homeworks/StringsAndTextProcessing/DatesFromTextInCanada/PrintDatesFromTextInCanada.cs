//Problem 19. Dates from text in Canada

//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

class PrintDatesFromTextInCanada
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-CA");
        Console.WriteLine("Please,enter a text:");
        string text = Console.ReadLine();
        string format = @"\b\d{2}.\d{2}.\d{4}\b";

        DateTime currentDate;
        foreach (Match match in Regex.Matches(text, format))
        {

            if (DateTime.TryParseExact(match.Value, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentDate))
            {
                Console.WriteLine(currentDate.ToShortDateString());
            }
        }
    }
}

