using System;

class SolveTheHorror
{
    static void Main()
    {
        string number = Console.ReadLine();
        long sum = 0;
        int counter = 0;

        for (int i = 0; i < number.Length; i++)
        {
            if (i % 2 == 0 && char.IsDigit(number[i]))
            {
                sum += int.Parse(number[i].ToString());
                counter++;
            }
        }

        Console.WriteLine("{0} {1}", counter,sum);
    }
}

