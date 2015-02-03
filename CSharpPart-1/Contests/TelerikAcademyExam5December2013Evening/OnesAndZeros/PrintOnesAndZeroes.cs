using System;

class PrintOnesAndZeroes
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        string binary = Convert.ToString(number, 2).PadLeft(32, '0');
        string[] One = { ".#.", "##.", ".#.", ".#.", "###" };
        string[] Zero = { "###", "#.#", "#.#", "#.#", "###" };

        for (int i = 0; i < One.Length; i++)
        {
            for (int j = 16; j < binary.Length; j++)
            {
                if (binary[j] == '1')
                {
                    Console.Write(One[i]);
                }
                else
                {
                    Console.Write(Zero[i]);
                }

                if (j != binary.Length - 1)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}

