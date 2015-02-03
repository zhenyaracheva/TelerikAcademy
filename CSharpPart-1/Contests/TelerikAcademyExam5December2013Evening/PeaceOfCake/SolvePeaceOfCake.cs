using System;

class SolvePeaceOfCake
{
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long d = long.Parse(Console.ReadLine());

        long nominator = (a * d) + (b * c);
        long denominator = b * d;
        decimal cakes = (decimal)nominator / (decimal)denominator;

        if ((int)cakes > 0)
        {
            Console.WriteLine((int)cakes);
        }
        else
        {
            Console.WriteLine("{0:F22}", cakes);
        }

        Console.WriteLine("{0}/{1}", nominator, denominator);

    }
}

