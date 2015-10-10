namespace CompareSimpleMath
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class TestMath<T> where T : struct, IComparable, IConvertible, IComparable<T>, IEquatable<T>, IFormattable
    {
        private const float FloatTestValue = 100.05f;
        private const double DoubleTestValue = 100.05d;
        private const decimal DecimalTestValue = 100.05m;

        public static void CompareSimpleMath(T value, int testTimesCycle, int testCount)
        {
            var operations = new char[] { '+', '-', '*', '/' };
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Test operator: " + operations[i]);
                TestSimpleOperation(operations[i], value, testTimesCycle, testCount);
            }
        }

        public static void CompareAdvancesMath(string type, int testTimesCycle, int testCount)
        {
            var value = GetFloatDoubleDecimalValue(type);

            var operations = new string[] { "sqrt", "log", "sin" };
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Test operator: " + operations[i]);
                TestAdvancedOperation(type, operations[i], value, testTimesCycle, testCount);
            }
        }

        private static dynamic GetFloatDoubleDecimalValue(string type)
        {
            if (type == "float")
            {
                return TestMath<T>.FloatTestValue;
            }
            else if (type == "double")
            {
                return TestMath<T>.DoubleTestValue;
            }
            else if (type == "decimal")
            {
                return TestMath<T>.DecimalTestValue;
            }
            else
            {
                throw new ArgumentException("Type must be float, double or decimal!");
            }
        }

        private static void TestAdvancedOperation(string type, string function, T value, int testTimesCycle, int testCount)
        {
            var allResults = new List<TimeSpan>();

            for (int testCircles = 0; testCircles < testTimesCycle; testCircles++)
            {
                dynamic result = 0;
                Stopwatch sw = Stopwatch.StartNew();
                double doubleValue;
                doubleValue = double.Parse(value.ToString());

                for (int testInRow = 0; testInRow < testCount; testInRow++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (type != "double")
                        {
                            doubleValue = double.Parse(value.ToString());
                        }

                        if (function == "sqrt")
                        {
                            result = Math.Sqrt(doubleValue);
                        }
                        else if (function == "log")
                        {
                            result = Math.Log(doubleValue);
                        }
                        else if (function == "sin")
                        {
                            result = Math.Sin(doubleValue);
                        }
                    }
                }

                sw.Stop();
                var currentTime = sw.Elapsed;
                Console.WriteLine(currentTime);
                allResults.Add(currentTime);
            }

            var doubleAverageTicks = allResults.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            Console.WriteLine("Average time: " + new TimeSpan(longAverageTicks));
            Console.WriteLine();
        }

        private static void TestSimpleOperation(char operation, T value, int testTimesCycle, int testCount)
        {
            var allResults = new List<TimeSpan>();

            for (int testCircles = 0; testCircles < testTimesCycle; testCircles++)
            {
                dynamic result = 0;
                Stopwatch sw = Stopwatch.StartNew();

                for (int testInRow = 0; testInRow < testCount; testInRow++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (operation == '+')
                        {
                            result += value;
                        }
                        else if (operation == '-')
                        {
                            result -= value;
                        }
                        else if (operation == '*')
                        {
                            result *= value;
                        }
                        else if (operation == '/')
                        {
                            result /= value;
                        }
                    }
                }

                sw.Stop();
                var currentTime = sw.Elapsed;
                Console.WriteLine(currentTime);
                allResults.Add(currentTime);
            }

            var doubleAverageTicks = allResults.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            Console.WriteLine("Average time: " + new TimeSpan(longAverageTicks));
            Console.WriteLine();
        }
    }
}