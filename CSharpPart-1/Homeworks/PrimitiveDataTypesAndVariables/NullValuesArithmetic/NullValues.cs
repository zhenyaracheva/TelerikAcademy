//Problem 12. Null Values Arithmetic

//Create a program that assigns null values to an integer and to a double variable.
//Try to print these variables at the console.
//Try to add some number or the null literal to these variables and print the result.

using System;

class NullValues
{
    static void Main()
    {
        int? integerVariable = null;
        double? doubleVariable = null;

        Console.Write("Is this integer with null  value: ");
        CheckVariable(integerVariable.ToString());
        Console.Write("Is this double with null value: ");
        CheckVariable(doubleVariable.ToString());

        integerVariable = 5;
        doubleVariable = 1.2345;

        Console.Write("Is this integer with null  value: ");
        CheckVariable(integerVariable.ToString());
        Console.Write("Is this double with null value: ");
        CheckVariable(doubleVariable.ToString());
    }

    private static void CheckVariable(string variable)
    {
        if (string.IsNullOrEmpty(variable))
        {
            Console.WriteLine("Yes!");
        }
        else
        {
            Console.WriteLine("No!");
            Console.WriteLine("Value is: {0}", variable);
        }
    }
}

