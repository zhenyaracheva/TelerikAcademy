namespace RefactorExamBitsToBitsTask
{
    using System;
    using System.Text;

    public class BitsToBits
    {
        public static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            long maxCountZeros = 0;
            long maxCountOnes = 0;
            long currentZeros = 0;
            long currentOnes = 0;

            StringBuilder binary = new StringBuilder();
            for (int i = 0; i < numbersCount; i++)
            {
                long number = long.Parse(Console.ReadLine());
                binary.Append(Convert.ToString(number, 2).PadLeft(30, '0'));
            }

            char currentSymbol = binary[0];

            for (int index = 0; index < binary.Length; index++)
            {
                if (currentSymbol == '0')
                {
                    while (currentSymbol == binary[index])
                    {
                        currentZeros++;

                        if (index + 1 < binary.Length)
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (maxCountZeros < currentZeros)
                    {
                        maxCountZeros = currentZeros;
                    }

                    currentZeros = 0;
                    currentSymbol = binary[index];

                    if (index != binary.Length - 1)
                    {
                        index--;
                    }
                }
                else if (currentSymbol == '1')
                {
                    while (currentSymbol == binary[index])
                    {
                        currentOnes++;

                        if (index + 1 < binary.Length)
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (maxCountOnes < currentOnes)
                    {
                        maxCountOnes = currentOnes;
                    }

                    currentSymbol = binary[index];
                    currentOnes = 0;

                    if (index != binary.Length - 1)
                    {
                        index--;
                    }
                }
            }

            Console.WriteLine(maxCountZeros);
            Console.WriteLine(maxCountOnes);
        }
    }
}
