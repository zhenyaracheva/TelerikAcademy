using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

class SolveBunnyFactory
{
    static void Main()
    {
        var cages = ReadInput();
        int cycle = 1;

        while (true)
        {
            if(cycle >= cages.Count)
            {
                break;
            }

            int s = 0;

            for (int i = 0; i < cycle; i++)
            {
                s += cages[i];
            }

            StringBuilder createNewGeneration = new StringBuilder();

            if ( s >= cages.Count)
            {
                break;
            }

            BigInteger bunniesSum = 0;
            BigInteger bunniesProduct = 1;

            for (int i = cycle; i < s + cycle; i++)
            {
                bunniesSum += cages[i];
                bunniesProduct *= cages[i];
            }

            createNewGeneration.Append(bunniesSum);
            createNewGeneration.Append(bunniesProduct);
            cages.RemoveRange(0, s + cycle);
            createNewGeneration.Append(string.Join(string.Empty, cages));
            cages.Clear();

            for (int i = 0; i < createNewGeneration.Length; i++)
            {
                if (createNewGeneration[i] != '0' && createNewGeneration[i] != '1')
                {
                    cages.Add(int.Parse(createNewGeneration[i].ToString()));
                }
            }

            cycle++;
        }

        Console.WriteLine(string.Join(" ", cages));
    }

    private static new List<int> ReadInput()
    {
        var cages = new List<int>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            cages.Add(int.Parse(input));
            input = Console.ReadLine();
        }

        return cages;
    }
}

