//Problem 5. Formatting Numbers

//Write a program that reads 3 numbers:
//integer a (0 <= a <= 500)
//floating-point b
//floating-point c
//The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
//The number a should be printed in hexadecimal, left aligned
//Then the number a should be printed in binary form, padded with zeroes
//The number b should be printed with 2 digits after the decimal point, right aligned
//The number c should be printed with 3 digits after the decimal point, left aligned.
//Examples:

//a	    b	    c	        result
//254	11.6	0.5	        FE  |0011111110| 11.60|0.500 |
//499	-0.5559	10000	    1F3 |0111110011| -0.56|10000 |
//0	    3	    -0.1234	    0   |0000000000| 3    |-0.123|

using System;

class FormatNumbers
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNumber = CheckNumber();

        Console.Write("Enter second number: ");
        float secondNumber = float.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        float thirdNumber = float.Parse(Console.ReadLine());

        string firstColumn = firstNumber.ToString("X").PadRight(10, ' ');
        string secondColumn = Convert.ToString(firstNumber,2).PadLeft(10, '0');
        

        Console.WriteLine("{0}|{1}|{2,10:F2}|{3,-10:F3}|", firstColumn,secondColumn, secondNumber, thirdNumber);
    }

    private static int CheckNumber()
    {
        int number = int.Parse(Console.ReadLine());

        while (number < 0 || number > 500)
        {
            Console.Write("Invalid number!Number cannot be negative or bigger than 500! Try again: ");
            number = int.Parse(Console.ReadLine());
        }

        return number;
    }
}

