using System;
using System.Text;

class SoleveNaBabaMiSmetalnika
{
    const int Height = 8;
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        char[,] smetalo = FillSmetalo(width);

        while (true)
        {
            string command = Console.ReadLine();
            int topcheta = 0;

            if (command == "left" || command == "right")
            {
                int row = CheckRow(smetalo);
                int col = CheckCol(smetalo);

                if (command == "left")
                {
                    for (int i = col; i >= 0; i--)
                    {
                        if (smetalo[row, i] == '1')
                        {
                            topcheta++;
                            smetalo[row, i] = '0';
                        }
                    }

                    for (int i = 0; i < topcheta; i++)
                    {
                        smetalo[row, i] = '1';
                    }
                }
                else if (command == "right")
                {
                    for (int i = col; i < smetalo.GetLength(1); i++)
                    {
                        if (smetalo[row, i] == '1')
                        {
                            topcheta++;
                            smetalo[row, i] = '0';
                        }
                    }

                    for (int i = 0; i < topcheta; i++)
                    {
                        smetalo[row, smetalo.GetLength(1) - i - 1] = '1';
                    }
                }
            }
            else if (command == "reset")
            {
                for (int row = 0; row < smetalo.GetLength(0); row++)
                {
                    topcheta = 0;

                    for (int col = 0; col < smetalo.GetLength(1); col++)
                    {
                        if (smetalo[row, col] == '1')
                        {
                            topcheta++;
                            smetalo[row, col] = '0';
                        }
                    }

                    for (int col = 0; col < topcheta; col++)
                    {
                        smetalo[row, col] = '1';
                    }
                }
            }
            else if (command == "stop")
            {
                long sum = 0;

                for (int row = 0; row < smetalo.GetLength(0); row++)
                {
                    StringBuilder number = new StringBuilder();
                    for (int col = 0; col < smetalo.GetLength(1); col++)
                    {
                        number.Append(smetalo[row, col]);
                    }

                    sum += Convert.ToInt64(number.ToString(), 2);

                }

                int emptyColumns = 0;

                for (int col = 0; col < smetalo.GetLength(1); col++)
                {
                    int countTopcheta = 0;
                    for (int row = 0; row < smetalo.GetLength(0); row++)
                    {
                        if (smetalo[row, col] == '1')
                        {
                            countTopcheta++;
                        }
                    }

                    if (countTopcheta == 0)
                    {
                        emptyColumns++;
                    }
                }

                Console.WriteLine(sum * emptyColumns);
                return;
            }
            else
            {
                throw new ArgumentException("Ivnalid command!");
            }
        }

    }

    private static int CheckCol(char[,] smetalo)
    {
        int col = int.Parse(Console.ReadLine());

        if (col < 0)
        {
            return 0;
        }
        else if (col >= smetalo.GetLength(1))
        {
            return smetalo.GetLength(1) - 1;
        }
        else
        {
            return col;
        }
    }

    private static int CheckRow(char[,] smetalo)
    {
        int row = int.Parse(Console.ReadLine());

        if (row < 0)
        {
            return 0;
        }
        else if (row >= smetalo.GetLength(0))
        {
            return smetalo.GetLength(0) - 1;
        }
        else
        {
            return row;
        }
    }
    
    private static char[,] FillSmetalo(int width)
    {
        char[,] smetalo = new char[Height, width];

        for (int row = 0; row < Height; row++)
        {
            int currerntNumber = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(currerntNumber, 2).PadLeft(width, '0');

            for (int col = 0; col < binary.Length; col++)
            {
                smetalo[row, col] = binary[col];
            }
        }

        return smetalo;
    }
}

