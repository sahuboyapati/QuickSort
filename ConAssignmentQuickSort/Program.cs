using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignQuickSort
{
    internal class Program
    {
        public static void quicksort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }
        private static void quicksort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotindex = Partition(array, left, right);
                quicksort(array, left, pivotindex - 1);
                quicksort(array, pivotindex + 1, right);
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
                    swap(array, i, j);
                }
            }
            swap(array, i + 1, right);
            return i + 1;
        }

        private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }



        public static void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        public static void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {

                int m = l + (r - l) / 2;

                sort(arr, l, m);
                sort(arr, m + 1, r);

                merge(arr, l, m, r);
            }
        }


        public static void Print(int[] arr)
        {
            Console.Write("{ ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.Write(" }\n");
        }

        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                    return false;
            }
            return true;
        }


        static void Main(string[] args)
        {

            int[] arr = { 12, 7, 3, 1, 8, 9, 15, 4, 5 };
            Console.WriteLine("original array for Quick Sort is \n");
            Print(arr);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            quicksort(arr);
            stopwatch1.Stop();
            Console.WriteLine("\nAfter applying quick sort elements are in ascending order\n");
            Print(arr);

            int[] arr1 = { 12, 7, 3, 1, 8, 9, 15, 4, 5 };
            Console.WriteLine("\nOriginal array for Merge sort array is \n");
            Print(arr1);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            sort(arr1, 0, arr1.Length - 1);
            stopwatch2.Stop();
            Console.WriteLine("\nAfter Merge Sorted array is\n");
            Print(arr1);


            Console.WriteLine("\nIs the array sorted correctly ?  " + IsSorted(arr1));
            Console.WriteLine($"\nArray size is {arr1.Length} \nTime Taken for quick sort is {stopwatch1.Elapsed.TotalMilliseconds} milliseconds  \nTime Taken for merge sort is {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");





            Console.ReadKey();



        }
    }
}