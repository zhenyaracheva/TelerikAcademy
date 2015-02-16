//Problem 6. String length

//Write a program that reads from the console a string of maximum 20 characters. If the length of the string 
//is less than 20, the rest of the characters should be filled with *.
//Print the result string into the console.

using System;

class PrintStringLength
{
    static void Main()
    {
        Console.Write("Please, enter a text (20 charactesr maximum):");
        string text = ValidateInput();
        Console.WriteLine(text.PadRight(20, '*'));
    }

    private static string ValidateInput()
    {
        string text = Console.ReadLine();

        while (text.Length > 20)
        {
            Console.WriteLine("Invalid input! Text lenght mustn't be bigger than 20 characters! Try again:");
            text = Console.ReadLine();
        }

        return text;
    }
}

