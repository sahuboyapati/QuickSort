using System;
using System.Diagnostics;

namespace ConAssignmentQuickSort
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n");
        }

        static void MeasureQuicksortPerformance(int arraySize)
        {
            int[] array = GenerateRandomArray(arraySize);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            QuickSort(array, 0, array.Length - 1);

            stopwatch.Stop();

            Console.WriteLine($"Array size: {arraySize}, Time taken: {stopwatch.ElapsedMilliseconds} ms, Sorted correctly: {IsSorted(array)}");
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1000); // Adjust the range as needed
            }

            return array;
        }

        // Method to check if the array is sorted
        public static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                    return false;
            }
            return true;
        }

        // Method to compare quicksort with merge sort
        static void CompareSortAlgorithms(int arraySize)
        {
            int[] quicksortArray = GenerateRandomArray(arraySize);
            int[] mergesortArray = CopyArray(quicksortArray);

            // Measure quicksort performance
            Stopwatch quicksortStopwatch = new Stopwatch();
            quicksortStopwatch.Start();
            QuickSort(quicksortArray, 0, quicksortArray.Length - 1);
            quicksortStopwatch.Stop();

            Console.WriteLine($"Quicksort - Array size: {arraySize}, Time taken: {quicksortStopwatch.ElapsedMilliseconds} ms, Sorted correctly: {IsSorted(quicksortArray)}");

            // Measure mergesort performance
            Stopwatch mergesortStopwatch = new Stopwatch();
            mergesortStopwatch.Start();
            MergeSort(mergesortArray, 0, mergesortArray.Length - 1);
            mergesortStopwatch.Stop();

            Console.WriteLine($"Mergesort - Array size: {arraySize}, Time taken: {mergesortStopwatch.ElapsedMilliseconds} ms, Sorted correctly: {IsSorted(mergesortArray)}");
        }

        // Merge sort implementation
        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private static void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }

        // Method to copy an array
        public static int[] CopyArray(int[] array)
        {
            int[] copy = new int[array.Length];
            Array.Copy(array, copy, array.Length);
            return copy;
        }

        static void Main(string[] args)
        {
            int[] array = { 5, 2, 4, 9, 7 };
            Console.WriteLine("Original Array is:");
            Print(array);

            // Measure Quicksort performance for the provided array
            MeasureQuicksortPerformance(array.Length);

            // Compare Quicksort with Merge Sort for various array sizes
            Console.WriteLine("\nComparison of Quicksort and Merge Sort:");

            CompareSortAlgorithms(5);
           

            Console.ReadKey();
        }
    }
}
