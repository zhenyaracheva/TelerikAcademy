//Problem 5. Workdays

//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;
using System.Collections.Generic;

class FindWorkdays
{
    static List<DateTime> Holidays = new List<DateTime>()
    {
        new DateTime(2015,1,1),
        new DateTime(2015,3,3),
        new DateTime(2015,4,10),
        new DateTime(2015,4,13),
        new DateTime(2015,4,13),
        new DateTime(2015,5,1),
        new DateTime(2015,5,6),
        new DateTime(2015,9,06), 
        new DateTime(2015,9,22),
        new DateTime(2015,11,1),
        new DateTime(2015,12,24),
        new DateTime(2015,12,25), 
        new DateTime(2015,12,30)

    };

    static void Main()
    {
        Console.Write("Please, enter a date in format DD/MM/YYYY: ");


        string[] date = Console.ReadLine().Split(new char[] { ' ', '/', '-', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int day = int.Parse(date[0]);
        int month = int.Parse(date[1]);
        int year = int.Parse(date[2]);
        DateTime futureDate = new DateTime(year, month, day);

        if (futureDate < DateTime.Today)
        {
            Console.WriteLine("Passed date!");
        }
        else
        {
            int workingDays = WorkDays(futureDate);

            Console.WriteLine("Working days between today and {0}/{1}/{2} are: {3}", futureDate.Day, futureDate.Month,
                futureDate.Year, workingDays);
        }
    }

    static int WorkDays(DateTime date)
    {
        DateTime dateToday = DateTime.Today;
        int counter = 0;

        while (dateToday <= date)
        {
            if (dateToday.Year != Holidays[0].Year)
            {
                for (int i = 0; i < Holidays.Count; i++)
                {
                    Holidays[i] = Holidays[i].AddYears(1);
                }
            }

            if (!Holidays.Contains(dateToday)
                && dateToday.DayOfWeek != DayOfWeek.Saturday
                && dateToday.DayOfWeek != DayOfWeek.Sunday)
            {
                counter++;
            }

            dateToday = dateToday.AddDays(1.00);
        }

        return counter;
    }
}

