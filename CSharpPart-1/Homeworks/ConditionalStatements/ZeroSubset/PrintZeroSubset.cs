//Problem 12.* Zero Subset

//We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
//Assume that repeating the same subset several times is not a problem.

using System;
using System.Collections.Generic;
using System.Text;

class PrintZeroSubset
{

    static void Main()
    {
        string[] num = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> solutions = new List<string>();
        StringBuilder result = new StringBuilder();

        bool isZeroSubset = false;

        for (int i = 0; i < num.Length; i++)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (int.Parse(num[i]) + int.Parse(num[j]) == 0)
                {
                    result.AppendFormat("{0} + {1} = 0", num[i], num[j]);

                    if (!solutions.Contains(result.ToString()))
                    {
                        solutions.Add(result.ToString());
                    }
                    isZeroSubset = true;
                    result.Clear();
                }
            }
        }

        for (int i = 0; i < num.Length; i++)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (j + 1 < num.Length)
                {
                    if (int.Parse(num[i]) + int.Parse(num[j]) + int.Parse(num[j + 1]) == 0)
                    {
                        result.AppendFormat("{0} + {1} + {2}= 0", num[i], num[j], num[j + 1]);

                        if (!solutions.Contains(result.ToString()))
                        {
                            solutions.Add(result.ToString());
                        }

                        isZeroSubset = true;
                        result.Clear();
                    }
                }
            }
        }

        for (int i = 0; i < num.Length; i++)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (j + 2 < num.Length)
                {
                    if (int.Parse(num[i]) + int.Parse(num[j]) + int.Parse(num[j + 1]) + int.Parse(num[j + 2]) == 0)
                    {
                        result.AppendFormat("{0} + {1} + {2} + {3}= 0", num[i], num[j], num[j + 1], num[j + 2]);

                        if (!solutions.Contains(result.ToString()))
                        {
                            solutions.Add(result.ToString());
                        }

                        isZeroSubset = true;
                        result.Clear();
                    }
                }
            }
        }

        if (int.Parse(num[0]) + int.Parse(num[1]) + int.Parse(num[2]) + int.Parse(num[3]) + int.Parse(num[4]) == 0)
        {
            result.AppendFormat("{0} + {1} + {2} + {3} + {4}= 0", num[0], num[1], num[2], num[3], num[4]);

            if (!solutions.Contains(result.ToString()))
            {
                solutions.Add(result.ToString());
            }

            isZeroSubset = true;
            result.Clear();
        }

        if (solutions.Count==0)
        {
            Console.WriteLine("No zero subset!");
        }
        else
        {
            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine(solutions[i]);
            }
        }
    }

}

