namespace VariablesDataExpressionsConstant
{
    using System;
    using System.Linq;

    public class VariablesDataExpressionsConstantsHW
    {
        public static void Main(string[] args)
        {
        }

        public void PrintMinMaxAverageElement(double[] numbers, int length)
        {
            double max = double.MinValue;
            double min = double.MaxValue;
            double sum = 0;

            for (int i = 0; i < length; i++)
            {
                var currentValue = numbers[i];
                sum += currentValue;

                if (currentValue > max)
                {
                    max = currentValue;
                }

                if (currentValue < min)
                {
                    min = currentValue;
                }
            }

            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Average: " + (sum / length));
        }
    }
}
