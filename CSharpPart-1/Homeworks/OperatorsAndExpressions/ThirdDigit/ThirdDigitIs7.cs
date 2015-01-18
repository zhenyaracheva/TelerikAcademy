//Problem 5. Third Digit is 7?

//Write an expression that checks for given integer if its third digit from right-to-left is 7.
//Examples:

// n	     Third digit 7?
// 5	         false
// 701	         true
// 9703	         true
// 877	         false
// 777877	     false
// 9999799	     true

using System;

class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Enter number: ");
        string number = Console.ReadLine();
        bool isSeven = false;

        Console.Write("Is the third digit from right-to-left 7: ");

        if (number.Length >= 3 && number[number.Length - 3] == '7')
        {
            isSeven = true;
        }

        Console.WriteLine(isSeven);
    }
}

