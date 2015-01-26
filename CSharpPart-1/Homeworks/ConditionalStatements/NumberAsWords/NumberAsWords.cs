//Problem 11.* Number as Words

//Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

using System;


class NumberAsWords
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        string numuberAsWord = NumberToWords(number);
        numuberAsWord = char.ToUpper(numuberAsWord[0]) + numuberAsWord.Substring(1);

        Console.WriteLine("Your number as word is: " + numuberAsWord);

    }

    private static string NumberToWords(int number)
    {
        if (number == 0)
        {
            return "zero";
        }

        if (number < 0)
        {
            return "minus " + NumberToWords(Math.Abs(number));
        }
        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
            {
                words += "and ";
            }

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
            {
                words += unitsMap[number];
            }
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                {
                    words += "-" + unitsMap[number % 10];
                }
            }
        }

        return words;
    }
}

