//Problem 9. Play with Int, Double and String

//Write a program that, depending on the user’s choice, inputs an int, double or string variable.
//If the variable is int or double, the program increases it by one.
//If the variable is a string, the program appends * at the end.
//Print the result at the console. Use switch statement.

using System;

class IntDoubleString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1--> int");
        Console.WriteLine("2--> double");
        Console.WriteLine("3--> string");
        Console.Write("Enter type: ");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1 || choice == 2)
        {
            if (choice == 2)
            {
                Console.Write("Please enter a double: ");
                double userNumber = double.Parse(Console.ReadLine());
                Console.WriteLine(userNumber + 1);
            }
            else
            {
                Console.Write("Please enter a int: ");
                int userNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(userNumber + 1);
            }
        }
        else if (choice == 3)
        {
            Console.WriteLine("Please enter a string: ");
            string userString = Console.ReadLine();
            Console.WriteLine(userString + "*");
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }
}

