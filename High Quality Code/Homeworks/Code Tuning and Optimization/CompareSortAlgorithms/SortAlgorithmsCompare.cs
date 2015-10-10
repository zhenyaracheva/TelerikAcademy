namespace CompareSortAlgorithms
{
    using System;

    public class SortAlgorithmsCompare
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Test InsertionSort");
            Console.WriteLine("----------------------------------------------------------------------");
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.InsertionSort, DataType.Double, 5, 100);
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.InsertionSort, DataType.Int, 5, 100);
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.InsertionSort, DataType.String, 5, 100);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Test SelectionSortArray");
            Console.WriteLine("----------------------------------------------------------------------");
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.SelectionSortArray, DataType.Double, 5, 100);
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.SelectionSortArray, DataType.Int, 5, 100);
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.SelectionSortArray, DataType.String, 5, 100);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Test QuickSort");
            Console.WriteLine("----------------------------------------------------------------------");
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.QuickSort, DataType.Double, 5, 100);
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.QuickSort, DataType.Int, 5, 100);
            SortAlgorithmTester.TestSortAlgorithm(Algorithm.QuickSort, DataType.String, 5, 100);
        }
    }
}
