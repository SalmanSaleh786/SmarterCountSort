using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    abstract class NumberSorter : ISort
    {
        protected float[] arrayToBeSorted = null;
        public NumberSorter(float[] arr) 
        {
            arrayToBeSorted = arr;
        }

        //List<int> sorted_list = new List<int>();
        //internal void CopyArray(List<int> unsortedList)
        //{
        //    sorted_list.Clear();
        //    foreach (int num in unsortedList)
        //    {
        //        sorted_list.Add(num);
        //    }
        //}
        //internal void UseInsertionSort(List<int> unsortedList)
        //{
        //    //Copy list
        //    CopyArray(unsortedList);
        //    int i, key, j;
        //    for (i = 1; i < sorted_list.Count; i++)
        //    {
        //        key = sorted_list[i];
        //        j = i - 1;

        //        // Move elements of arr[0..i-1],
        //        // that are greater than key,
        //        // to one position ahead of their
        //        // current position
        //        while (j >= 0 && sorted_list[j] > key)
        //        {
        //            sorted_list[j + 1] = sorted_list[j];
        //            j = j - 1;
        //        }
        //        sorted_list[j + 1] = key;
        //    }
        //}


        //internal void UseBucketSort(List<int> unsortedList)
        //{
        //    //Copy list
        //    //CopyArray(unsortedList);
        //    float[] unsortedArray = new float[unsortedList.Count];
        //    for(int i=0; i < unsortedArray.Length; ++i)
        //    {
        //      unsortedArray[i] = (float)(unsortedList[i] / 10000.0);
        //    }
        //    bucketSort(unsortedArray, unsortedArray.Length);
        //    for (int i = 0; i < unsortedArray.Length; ++i)
        //    {
        //        unsortedArray[i] = (float)(unsortedArray[i] * 10000.0);
        //    }
        //    //unsortedArray is now sorted
        //}
        //internal void UseRadixSort(List<int> unsortedList)
        //{
        //    //Copy list
        //    CopyArray(unsortedList);
        //    radixsort(sorted_list.ToArray(), sorted_list.Count);
        //}
        //public static int getMax(int[] arr, int n)
        //{
        //    int mx = arr[0];
        //    for (int i = 1; i < n; i++)
        //        if (arr[i] > mx)
        //            mx = arr[i];
        //    return mx;
        //}


        //// The main function to that sorts arr[] of size n using
        //// Radix Sort
        //public static void radixsort(int[] arr, int n)
        //{
        //    // Find the maximum number to know number of digits
        //    int m = getMax(arr, n);

        //    // Do counting sort for every digit. Note that
        //    // instead of passing digit number, exp is passed.
        //    // exp is 10^i where i is current digit number
        //    for (int exp = 1; m / exp > 0; exp *= 10)
        //        countSort(arr, n, exp);
        //}



        //internal virtual void SortNumbers()
        //{
        //    throw new NotImplementedException();
        //}
        public virtual float[] SortNumbers()
        {
            return null;
        }
        
    }
}
