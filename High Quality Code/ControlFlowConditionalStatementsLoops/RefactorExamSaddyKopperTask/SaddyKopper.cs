namespace RefactorExamSaddyKopperTask
{
    using System;
    using System.Numerics;
    using System.Text;

    public class SaddyKopper
    {
        private const int MaxTransformation = 10;

        public static void Main()
        {
            string number = Console.ReadLine();
            BigInteger sum = BigInteger.Parse(number);
            StringBuilder input = new StringBuilder(number);
            int transformations = TransformingNumber(sum, input);

            if (transformations < SaddyKopper.MaxTransformation)
            {
                Console.WriteLine(transformations);
            }

            Console.WriteLine(sum);
        }

        private static int TransformingNumber(BigInteger sum, StringBuilder input)
        {
            int transformations = 0;

            while (sum.ToString().Length > 1)
            {
                input = new StringBuilder(sum.ToString());
                sum = 1;

                while (input.Length > 0)
                {
                    input.Length--;
                    int currentNumber = 0;

                    for (int index = 0; index < input.Length; index++)
                    {
                        if (index % 2 == 0)
                        {
                            currentNumber += int.Parse(input[index].ToString());
                        }
                    }

                    if (input.Length > 0)
                    {
                        sum *= currentNumber;
                    }
                }

                transformations++;

                if (transformations >= SaddyKopper.MaxTransformation)
                {
                    break;
                }
            }

            return transformations;
        }
    }
}
