//Problem 15.* Age after 10 Years

//Write a program to read your birthday from the console and print how old you are now and how old you will be after 
//10 years.

using System;

class AgeAfter
{
    static void Main()
    {
        Console.Write("Write when is your birthday: ");
        DateTime birthday = DateTime.Parse(Console.ReadLine());
        int ageNow = DateTime.Today.Year - birthday.Year;

        while (ageNow < 0)
        {
            Console.Write("Wrong date, try again: ");
            birthday = DateTime.Parse(Console.ReadLine());
            ageNow = DateTime.Today.Year - birthday.Year;
        }

        if (birthday.Month > DateTime.Today.Month)
        {
            ageNow--;
        }
        else if (birthday.Month == DateTime.Today.Month)
        {
            if (birthday.Day > DateTime.Today.Day)
            {
                ageNow--;
            }
        }

        Console.WriteLine("You are {0} years old", ageNow);
        Console.WriteLine("After 10 years you will be {0}!", ageNow + 10);
    }
}

