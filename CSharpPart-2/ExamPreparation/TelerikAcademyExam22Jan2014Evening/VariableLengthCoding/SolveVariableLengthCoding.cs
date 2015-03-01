using System;
using System.Linq;
using System.Text;

class SolveVariableLengthCoding
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var text = FillText(numbers);
        var dict = FillDict();

        var result = new StringBuilder();
        int counter = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '1')
            {
                counter++;
            }
            else
            {
                result.Append(dict[counter]);
                counter = 0;
            }
        }

        if (counter > 0)
        {
            result.Append(dict[counter]);
        }

        Console.WriteLine(result);
    }

    private static char[] FillDict()
    {
        int n = int.Parse(Console.ReadLine());
        var dict = new char[n + 1];

        for (int i = 0; i < n; i++)
        {
            string currentPair = Console.ReadLine();
            char symbol = currentPair[0];
            int index = int.Parse(currentPair.Substring(1));
            dict[index] = symbol;
        }

        return dict;
    }


    private static StringBuilder FillText(int[] numbers)
    {
        StringBuilder text = new StringBuilder();

        for (int i = 0; i < numbers.Length; i++)
        {
            text.Append(Convert.ToString(numbers[i], 2).PadLeft(8, '0'));
        }

        return text;
    }
}

