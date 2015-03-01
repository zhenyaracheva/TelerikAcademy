using System;
using System.Collections.Generic;
using System.Text;

class SolveStrangeLandNumbers
{
    static int numSystem = 7;

    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder numberAsSeven = ConvertToDigits(input);
        long converted = ConvertToDecimal(numberAsSeven);
        Console.WriteLine(converted);
    }

    private static long ConvertToDecimal(StringBuilder number)
    {
        int power = number.Length - 1;
        long result = 0;

        for (int i = 0; i < number.Length; i++)
        {
            result += int.Parse(number[i].ToString()) * (long)Math.Pow(numSystem, power);
            power--;
        }

        return result;
    }

    private static StringBuilder ConvertToDigits(string input)
    {
        List<string> numbers = new List<string>() { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
        StringBuilder number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLower(input[i]))
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (input[i] == numbers[j][0])
                    {
                        number.Append(j);
                        i += numbers[j].Length - 1;
                        break;
                    }
                }
            }
        }

        return number;
    }
}

