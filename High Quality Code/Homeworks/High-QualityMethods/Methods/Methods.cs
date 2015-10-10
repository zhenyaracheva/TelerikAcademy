namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitAsWord(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");

            bool horizontal = OnSameLine(-1, 2.5);
            bool vertical = OnSameLine(3, 3);
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            ValidateTriangle(sideA, sideB, sideC);

            double s = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
            return area;
        }

        public static string DigitAsWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Invalid digit!";
            }
        }

        public static int FindMaxNumber(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty!");
            }

            var maxNumber = numbers[0];

            for (int index = 1; index < numbers.Length; index++)
            {
                if (numbers[index] > maxNumber)
                {
                    maxNumber = numbers[index];
                }
            }

            return maxNumber;
        }

        public static void PrintNumberInFormat(object number, string format)
        {
            if (!IsNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format!");
            }
        }

        public static double CalculateDistance(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            var distanceX = secondPointX - firstPointX;
            var distanceY = secondPointY - firstPointY;
            double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));

            return distance;
        }

        public static bool OnSameLine(double firstPointDimenssion, double secondPointDimenssion)
        {
            return firstPointDimenssion == secondPointDimenssion;
        }

        private static void ValidateTriangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides must be positive numbers!");
            }
            else if (sideA + sideB < sideC)
            {
                throw new ArgumentOutOfRangeException("Invalid triangle");
            }
            else if (sideA + sideC < sideB)
            {
                throw new ArgumentOutOfRangeException("Invalid triangle");
            }
            else if (sideB + sideC < sideA)
            {
                throw new ArgumentOutOfRangeException("Invalid triangle");
            }
        }

        private static bool IsNumber(object value)
        {
            return value is sbyte
             || value is byte
             || value is short
             || value is ushort
             || value is int
             || value is uint
             || value is long
             || value is ulong
             || value is float
             || value is double
             || value is decimal;
        }
    }
}
