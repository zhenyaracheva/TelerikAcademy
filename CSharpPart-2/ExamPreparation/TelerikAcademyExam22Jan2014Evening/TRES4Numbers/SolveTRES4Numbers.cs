using System;
using System.Text;
using System.Numerics;

class SolveTRES4Numbers
{
    const int numSystem = 9;

    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        string converted = ConvertToNineNum(number);
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < converted.Length; i++)
        {
            output.Append(ConvertDigit(converted[i]));
        }

        Console.WriteLine(output.ToString());
    }

    private static string ConvertToNineNum(BigInteger number)
    {
        StringBuilder result = new StringBuilder();

        if (number == 0)
        {
            return "0";
        }

        while (number > 0)
        {
            BigInteger remainder = number % numSystem;
            result.Insert(0, remainder);
            number /= numSystem;
        }

        return result.ToString();
    }

    private static string ConvertDigit(char digit)
    {
        switch (digit)
        {
            case '0': return "LON+";
            case '1': return "VK-";
            case '2': return "*ACAD";
            case '3': return "^MIM";
            case '4': return "ERIK|";
            case '5': return "SEY&";
            case '6': return "EMY>>";
            case '7': return "/TEL";
            case '8': return "<<DON";
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}

