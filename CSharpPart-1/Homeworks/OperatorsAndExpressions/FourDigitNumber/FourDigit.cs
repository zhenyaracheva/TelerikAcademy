//Problem 6. Four-Digit Number

//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
//Prints on the console the number in reversed order: dcba (in our example 1102).
//Puts the last digit in the first position: dabc (in our example 1201).
//Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0.

//Examples:

//n 	sum of digits	 reversed	 last digit in front	    second and third digits exchanged
//2011	    4	           1102	            1201	                        2101
//3333	    12	           3333	            3333	                        3333
//9876	    30	           6789	            6987	                        9786

using System;
using System.Text;

class FourDigit
{
    static void Main()
    {
        Console.Write("Enter a four-digit number in format abcd (e.g. 2011): ");

        string number = FindValidNumber();


        int sum = 0;
        StringBuilder reversed = new StringBuilder();

        for (int i = number.Length - 1; i >= 0; i--)
        {
            reversed.Append(number[i]);
            sum += int.Parse(number[i].ToString());
        }

        Console.WriteLine("The sum of the sum of the digits is: {0}", sum);
        Console.WriteLine("The number in reversed order is: {0}", reversed.ToString());
        Console.WriteLine("Last digit in front: {0}{1}{2}{3}", number[number.Length - 1], number[0], number[1], number[2]);
        Console.WriteLine("Second and third digits exchanged: {0}{1}{2}{3}", number[0], number[2], number[1], number[3]);
    }

    private static string FindValidNumber()
    {
        string number;
        while (true)
        {
            number = Console.ReadLine();
            bool isValidNumber = true; ;

            if (number.Length != 4)
            {
                isValidNumber = false;
            }
            else
            {
                int counter = 0;

                if (number[0] == '0')
                {
                    isValidNumber = false;
                }
                else
                {
                    for (int i = 0; i < number.Length; i++)
                    {
                        if (!char.IsDigit(number[i]))
                        {
                            isValidNumber = false;
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }

                    if (counter == 4)
                    {
                        isValidNumber = true;
                    }
                }

            }

            if (isValidNumber)
            {
                break;
            }

            Console.Write("Wrong number! Try again: ");
        }

        return number;
    }
}

