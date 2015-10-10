namespace CompareSortAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class SortAlgorithmTester
    {
        private const DataType[] Types = new DataType[] { DataType.Double, DataType.Int, DataType.String };
        private const Algorithm[] Algorithms = new Algorithm[] { Algorithm.InsertionSort, Algorithm.QuickSort, Algorithm.SelectionSortArray };

        private const string DoubleRandomMessage = "double random array";
        private const string DoubleSortMessage = "double sort array";
        private const string DoubleReversedMessage = "double reversed array";

        private const string IntRandomMessage = "int random array";
        private const string InSortMessage = "int sort array";
        private const string IntReversedMessage = "int reversed array";

        private const string StringRandomMessage = "string random array";
        private const string StringSortMessage = "string sort array";
        private const string StringReversedMessage = "string reversed array";

        private static double[] doubleRandomArray = new double[] { 96.01, 15.00, 66.03, 90.04, 35.53, 94.49, 71.17, 61.16, 34.34, 14.41 };
        private static double[] doubleSortArray = new double[] { 14.41, 15.00, 16.03, 20.04, 35.53, 44.49, 51.17, 61.16, 94.49, 96.01 };
        private static double[] doubleReversedArray = new double[] { 96.01, 94.00, 66.03, 61.04, 51.53, 44.49, 35.17, 20.16, 16.34, 15.41 };

        private static int[] intRandomArray = new int[] { 96, 15, 66, 90, 35, 94, 71, 61, 34, 14 };
        private static int[] intSortArray = new int[] { 14, 15, 16, 20, 35, 44, 51, 61, 94, 96 };
        private static int[] intReversedArray = new int[] { 96, 94, 66, 61, 51, 44, 35, 20, 16, 15 };

        private static string[] stringRandomArray = new string[] { "ATest", "CTest", "ZTest", "AATest", "STest", "ITest", "HTest", "ITest", "IZTest", "NTest" };
        private static string[] stringSortArray = new string[] { "ATest", "BTest", "CTest", "DATest", "ETest", "FTest", "JTest", "HTest", "ITest", "ZTest" };
        private static string[] stringReversedArray = new string[] { "ZTest", "ITest", "HTest", "JTest", "FTest", "ETest", "DTest", "CTest", "BTest", "ATest" };

        public static void TestSortAlgorithm(Algorithm algorithm, DataType dataType, int loops, int iterations)
        {
            if (algorithm == Algorithm.InsertionSort)
            {
                if (dataType == DataType.Double)
                {
                    TestInsertionSortAlgorithm<double>(SortAlgorithmTester.doubleRandomArray, loops, iterations, SortAlgorithmTester.DoubleRandomMessage);
                    TestInsertionSortAlgorithm<double>(SortAlgorithmTester.doubleReversedArray, loops, iterations, SortAlgorithmTester.DoubleReversedMessage);
                    TestInsertionSortAlgorithm<double>(SortAlgorithmTester.doubleSortArray, loops, iterations, SortAlgorithmTester.DoubleSortMessage);
                }
                else if (dataType == DataType.Int)
                {
                    TestInsertionSortAlgorithm<int>(SortAlgorithmTester.intRandomArray, loops, iterations, SortAlgorithmTester.IntRandomMessage);
                    TestInsertionSortAlgorithm<int>(SortAlgorithmTester.intReversedArray, loops, iterations, SortAlgorithmTester.IntReversedMessage);
                    TestInsertionSortAlgorithm<int>(SortAlgorithmTester.intSortArray, loops, iterations, SortAlgorithmTester.InSortMessage);
                }
                else if (dataType == DataType.String)
                {
                    TestInsertionSortAlgorithm<string>(SortAlgorithmTester.stringRandomArray, loops, iterations, SortAlgorithmTester.StringRandomMessage);
                    TestInsertionSortAlgorithm<string>(SortAlgorithmTester.stringReversedArray, loops, iterations, SortAlgorithmTester.StringReversedMessage);
                    TestInsertionSortAlgorithm<string>(SortAlgorithmTester.stringSortArray, loops, iterations, SortAlgorithmTester.StringSortMessage);
                }
            }
            else if (algorithm == Algorithm.SelectionSortArray)
            {
                if (dataType == DataType.Double)
                {
                    TestSelectionSortAlgorithm<double>(SortAlgorithmTester.doubleRandomArray, loops, iterations, SortAlgorithmTester.DoubleRandomMessage);
                    TestSelectionSortAlgorithm<double>(SortAlgorithmTester.doubleReversedArray, loops, iterations, SortAlgorithmTester.DoubleReversedMessage);
                    TestSelectionSortAlgorithm<double>(SortAlgorithmTester.doubleSortArray, loops, iterations, SortAlgorithmTester.DoubleSortMessage);
                }
                else if (dataType == DataType.Int)
                {
                    TestSelectionSortAlgorithm<int>(SortAlgorithmTester.intRandomArray, loops, iterations, SortAlgorithmTester.IntRandomMessage);
                    TestSelectionSortAlgorithm<int>(SortAlgorithmTester.intReversedArray, loops, iterations, SortAlgorithmTester.IntReversedMessage);
                    TestSelectionSortAlgorithm<int>(SortAlgorithmTester.intSortArray, loops, iterations, SortAlgorithmTester.InSortMessage);
                }
                else if (dataType == DataType.String)
                {
                    TestSelectionSortAlgorithm<string>(SortAlgorithmTester.stringRandomArray, loops, iterations, SortAlgorithmTester.StringRandomMessage);
                    TestSelectionSortAlgorithm<string>(SortAlgorithmTester.stringReversedArray, loops, iterations, SortAlgorithmTester.StringReversedMessage);
                    TestSelectionSortAlgorithm<string>(SortAlgorithmTester.stringSortArray, loops, iterations, SortAlgorithmTester.StringSortMessage);
                }
            }
            else if (algorithm == Algorithm.QuickSort)
            {
                if (dataType == DataType.Double)
                {
                    TestQuickSortAlgorithm<double>(SortAlgorithmTester.doubleRandomArray, loops, iterations, SortAlgorithmTester.DoubleRandomMessage);
                    TestQuickSortAlgorithm<double>(SortAlgorithmTester.doubleReversedArray, loops, iterations, SortAlgorithmTester.DoubleRandomMessage);
                    TestQuickSortAlgorithm<double>(SortAlgorithmTester.doubleSortArray, loops, iterations, SortAlgorithmTester.DoubleRandomMessage);
                }
                else if (dataType == DataType.Int)
                {
                    TestQuickSortAlgorithm<int>(SortAlgorithmTester.intRandomArray, loops, iterations, SortAlgorithmTester.IntRandomMessage);
                    TestQuickSortAlgorithm<int>(SortAlgorithmTester.intReversedArray, loops, iterations, SortAlgorithmTester.IntReversedMessage);
                    TestQuickSortAlgorithm<int>(SortAlgorithmTester.intSortArray, loops, iterations, SortAlgorithmTester.InSortMessage);
                }
                else if (dataType == DataType.String)
                {
                    TestQuickSortAlgorithm<string>(SortAlgorithmTester.stringRandomArray, loops, iterations, SortAlgorithmTester.StringRandomMessage);
                    TestQuickSortAlgorithm<string>(SortAlgorithmTester.stringReversedArray, loops, iterations, SortAlgorithmTester.StringReversedMessage);
                    TestQuickSortAlgorithm<string>(SortAlgorithmTester.stringSortArray, loops, iterations, SortAlgorithmTester.StringSortMessage);
                }
            }
        }

        private static void TestInsertionSortAlgorithm<T>(T[] arr, int loops, int iterations, string message) where T : IComparable
        {
            Console.WriteLine("Testing InsertionSort Algorithm: " + message);
            var allResults = new List<TimeSpan>();
            for (int loopIndex = 0; loopIndex < loops; loopIndex++)
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int iteration = 0; iteration < iterations; iteration++)
                {
                    SortAlgorithms.InsertionSort<T>(arr);
                }

                sw.Stop();
                var time = sw.Elapsed;
                allResults.Add(time);
                Console.WriteLine(time);
            }

            var doubleAverageTicks = allResults.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            Console.WriteLine("Average time: " + new TimeSpan(longAverageTicks));
            Console.WriteLine();
        }

        private static void TestSelectionSortAlgorithm<T>(T[] arr, int loops, int iterations, string message) where T : IComparable
        {
            Console.WriteLine("Testing SelectionSort Algorithm: " + message);
            var allResults = new List<TimeSpan>();
            for (int loopIndex = 0; loopIndex < loops; loopIndex++)
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int iteration = 0; iteration < iterations; iteration++)
                {
                    SortAlgorithms.SelectionSortArray<T>(arr);
                }

                sw.Stop();
                var time = sw.Elapsed;
                allResults.Add(time);
                Console.WriteLine(time);
            }

            var doubleAverageTicks = allResults.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            Console.WriteLine("Average time: " + new TimeSpan(longAverageTicks));
            Console.WriteLine();
        }

        private static void TestQuickSortAlgorithm<T>(T[] arr, int loops, int iterations, string message) where T : IComparable
        {
            Console.WriteLine("Testing QuickSort Algorithm: " + message);
            var allResults = new List<TimeSpan>();
            for (int loopIndex = 0; loopIndex < loops; loopIndex++)
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int iteration = 0; iteration < iterations; iteration++)
                {
                    SortAlgorithms.QuickSort<T>(arr);
                }

                sw.Stop();
                var time = sw.Elapsed;
                allResults.Add(time);
                Console.WriteLine(time);
            }

            var doubleAverageTicks = allResults.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            Console.WriteLine("Average time: " + new TimeSpan(longAverageTicks));
            Console.WriteLine();
        }
    }
}