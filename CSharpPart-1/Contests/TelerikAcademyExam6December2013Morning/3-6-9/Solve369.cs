﻿using System;

class Solve369
{
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());

        long result = 0;

        if (b == 3)
        {
            result = a + c;
        }
        else if (b == 6)
        {
            result = a * c;
        }
        else if (b == 9)
        {
            result = a % c;
        }

        if (result % 3 == 0)
        {
            Console.WriteLine(result / 3);
        }
        else
        {
            Console.WriteLine(result % 3);
        }

        Console.WriteLine(result);
    }
}

