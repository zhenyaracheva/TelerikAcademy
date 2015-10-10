namespace CompareSortAlgorithms
{
    using System;
    using System.Collections.Generic;

    public static class SortAlgorithms
    {
        public static void InsertionSort<T>(T[] arr, Comparer<T> comparer = null) where T : IComparable
        {
            comparer = comparer ?? Comparer<T>.Default;
            int sortedArrayIndex;
            T insertValue;

            for (int outer = 1; outer < arr.Length; outer++)
            {
                insertValue = arr[outer];
                sortedArrayIndex = outer;
                while (sortedArrayIndex > 0 && comparer.Compare(arr[sortedArrayIndex - 1], insertValue) >= 0)
                {
                    arr[sortedArrayIndex] = arr[sortedArrayIndex - 1];
                    sortedArrayIndex -= 1;
                }

                arr[sortedArrayIndex] = insertValue;
            }
        }

        public static void SelectionSortArray<T>(T[] array, Comparer<T> comparer = null) where T : IComparable
        {
            comparer = comparer ?? Comparer<T>.Default;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[min], array[j]) > 0)
                    {
                        min = j;
                    }
                }

                T temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        public static void QuickSort<T>(T[] collection, Comparer<T> comparer = null) where T : IComparable
        {
            comparer = comparer ?? Comparer<T>.Default;
            QuickSortRecursive(collection, 0, collection.Length - 1, comparer);
        }

        private static void QuickSortRecursive<T>(T[] collection, int left, int right, Comparer<T> comparer) where T : IComparable
        {
            T pivot = collection[(left + right) / 2];

            int i = left;
            int j = right;

            while (i <= j)
            {
                while (comparer.Compare(collection[i], pivot) < 0)
                {
                    i++;
                }

                while (comparer.Compare(collection[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSortRecursive(collection, left, j, comparer);
            }

            if (i < right)
            {
                QuickSortRecursive(collection, i, right, comparer);
            }
        }
    }
}
