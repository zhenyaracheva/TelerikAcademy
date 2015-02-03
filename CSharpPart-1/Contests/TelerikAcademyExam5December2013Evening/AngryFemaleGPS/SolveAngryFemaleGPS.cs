using System;

class SolveAngryFemaleGPS
{
    static void Main()
    {
        string number = Console.ReadLine();
        long oddNumbersSum = 0;
        long evenNumberSum = 0;

        for (int i = 0; i < number.Length; i++)
        {
            if (char.IsDigit(number[i]))
            {
                int num = int.Parse(number[i].ToString());

                if (num % 2 == 0)
                {
                    evenNumberSum += num;
                }
                else
                {
                    oddNumbersSum += num;
                }
            }
        }

        if (evenNumberSum > oddNumbersSum)
        {
            Console.WriteLine("{0} {1}", "right",evenNumberSum);
        }
        else if (evenNumberSum< oddNumbersSum)
        {
            Console.WriteLine("{0} {1}", "left", oddNumbersSum);
        }
        else
        {
            Console.WriteLine("{0} {1}", "straight", evenNumberSum);
        }
    }
}

