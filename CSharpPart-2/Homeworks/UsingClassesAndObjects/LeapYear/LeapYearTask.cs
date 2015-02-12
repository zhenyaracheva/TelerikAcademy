//Problem 1. Leap year

//Write a program that reads a year from the console and checks whether it is a leap one.
//Use System.DateTime.

using System;

class LeapYearTask
{
    static void Main()
    {
        Console.Write("Please, enter an year: ");
        DateTime currerntYear = new DateTime(int.Parse(Console.ReadLine()), 2, 1);
        Console.WriteLine("Is {0} leap year: {1}!", currerntYear.Year, DateTime.IsLeapYear(currerntYear.Year));
    }
}

