//Problem 13. Solve tasks

//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//Create appropriate methods.

//Provide a simple text-based menu for the user to choose which task to solve.

//Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;
using System.Linq;
using System.Threading;
using System.Globalization;

class Tasks
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Choose which task to solve:");
        Console.WriteLine("Press 1 ----> Reverses the digits of a number!");
        Console.WriteLine("Press 2 ----> Calculates the average of a sequence of integers!");
        Console.WriteLine("Press 3 ----> Solves a linear equation a * x + b = 0!");
        Console.Write("Please, enter your choice: ");
        int choice = CheckChoice();

        if (choice == 1)
        {
            Console.Write("Please, enter a positive number: ");
            decimal number = CheckValidNumber();
            Console.WriteLine("Reversed number {0} is {1}", number, ReverseNumber(number));
        }
        else if (choice == 2)
        {
            Console.WriteLine("Please, enter numbers (separate by space):");
            int[] arrayOfNumbers = CheckValidArray();
            Console.WriteLine("Average = {0}", Average(arrayOfNumbers));
        }
        else if (choice == 3)
        {
            Console.Write("Please, enter a linear equation (a * x + b = 0): ");
            string[] linearEquation = CheckLinearEquation();

            decimal xNumber = decimal.Parse(linearEquation[0]);
            char unknownChar = Convert.ToChar(linearEquation[1]);
            char operation = Convert.ToChar(linearEquation[2]);
            decimal knownNumber = decimal.Parse(linearEquation[3]);
            decimal resultNumber = decimal.Parse(linearEquation[4]);
            decimal result = 0;

            switch (operation)
            {
                case '+': result = (resultNumber - knownNumber) / xNumber;
                    break;
                case '-': result = (resultNumber + knownNumber) / xNumber;
                    break;
                case '/': result = (resultNumber * knownNumber) / xNumber;
                    break;
                default: throw new ArgumentException("Invalid operation!");
            }

            Console.WriteLine("{0} = {1}", unknownChar, result);
        }
    }

    private static string[] CheckLinearEquation()
    {
        string[] linearEquation = PrepareInput();

        while (true)
        {
            if (linearEquation[0] == "0")
            {
                Console.Write("\"a\" cannot be 0! Try again: ");
                linearEquation = linearEquation = PrepareInput();
            }
            else if (linearEquation.Length != 5)
            {
                Console.Write("Invalid linear equation! Try again: ");
                linearEquation = linearEquation = PrepareInput();
            }

            if (linearEquation[0]=="-")
            {
                linearEquation[0] = "-1";
            }

            break;
        }

        return linearEquation;
    }

    private static string[] PrepareInput()
    {
        string input = Console.ReadLine();
        string unknownChar = string.Empty;
        
        if (char.IsLetter(input[0]))
        {
            input = "1" + input;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]))
            {
                unknownChar = input[i].ToString();
                break;
            }
        }

        string newStringChar = string.Format(" {0} ", unknownChar);
        input = input.Replace(unknownChar, newStringChar);
        input = input.Replace(",", ".");
        input = input.Replace("/", " / ");
        input = input.Replace("-", " - ");
        input = input.Replace("+", " + ");
        input = input.Replace("=", " = ");
        string[] validInput = input.Split(new char[] { ' ', '*', '=' }, StringSplitOptions.RemoveEmptyEntries);

        return validInput;
    }

    private static int CheckChoice()
    {
        int choice = int.Parse(Console.ReadLine());

        while (choice < 1 || choice > 3)
        {
            Console.Write("Invalid operation! Try again: ");
            choice = int.Parse(Console.ReadLine());
        }

        return choice;
    }

    private static int[] CheckValidArray()
    {
        string[] arrayOfStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (arrayOfStrings.Length <= 0)
        {
            Console.WriteLine("Empty array! Try again:");
            arrayOfStrings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        int[] arrayOfNumbers = arrayOfStrings.Select(int.Parse).ToArray();

        return arrayOfNumbers;
    }

    private static decimal CheckValidNumber()
    {
        string num = Console.ReadLine();
        num = num.Replace(",", ".");

        decimal number = decimal.Parse(num);

        while (number < 0)
        {
            number = decimal.Parse(Console.ReadLine());
        }

        return number;
    }

    private static decimal ReverseNumber(decimal number)
    {
        return decimal.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()));
    }

    private static double Average(int[] arrayOfNumbers)
    {
        return arrayOfNumbers.Average();
    }
}

