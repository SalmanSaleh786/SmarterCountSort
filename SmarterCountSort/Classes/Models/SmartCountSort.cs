using AdvancedAlgo_Assignment1.Classes.HelperClasses;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    internal class SmartCountSort : NumberSorter
    {
        int[] countArray;
        int max = 0;
        int min = 0;
        public SmartCountSort(float[] arr) : base(arr)
        {

        }
        private float[] SortArray(float[] unsortedArr)
        {
            //Finding the max and min number
            foreach (float num in unsortedArr)
            {
                if (num > max)
                {
                    max = (int)Math.Ceiling(num);
                }
                if (num < min)
                {
                    min = (int)Math.Floor(num);
                }
            }
            
            DecimalCollection[] decimalArray;
            //int length = (max - min) + 1 > unsortedArr.Length ? (max - min + 1) : unsortedArr.Length;
            int length = 0;
            if (min < 0)
            {
                length = min * -1;
                length += max;
            }
            else
            {
                length = max - min + 1;
            }

            length += 1;
            //Creating the count array, it will store the occurence of each number
            countArray = new int[length];
            decimalArray = new DecimalCollection[length];
            for (int i = 0; i < decimalArray.Length; ++i)
                decimalArray[i] = new DecimalCollection();
            //Initializing the count array with -1, Elements with -1 will be ignored at the last
            Utils.Populate(countArray, -1);
            for (int i = 0; i < unsortedArr.Length; ++i)
            {
                //Updating the count array accordingly
                if (unsortedArr[i] < 0)
                {
                    countArray[max + (int)(unsortedArr[i] * -1)] += 1;
                    decimalArray[max + (int)(unsortedArr[i] * -1)].InsertionSortAdd(Utils.GetDecimals(unsortedArr[i])); 
                }
                else
                {
                    countArray[(int)(unsortedArr[i])] += 1;
                    decimalArray[(int)(unsortedArr[i])].InsertionSortAdd(Utils.GetDecimals(unsortedArr[i]));
                }

            }
            //Interim result array
            float[] finalSortedArray = new float[unsortedArr.Length];
            int j = 0;
            for (int i = countArray.Length - 1; i > max; --i)
            {
                while (countArray[i] >= 0)
                {
                    finalSortedArray[j] = (i - max) * -1;
                    if (decimalArray[i-max].Decimals.Count > 0)
                    {
                        finalSortedArray[j] += (float)(decimalArray[i-max].Decimals.First()*0.01);
                        decimalArray[i-max].Decimals.RemoveAt(0);
                    }
                    ++j;
                    --countArray[i];
                }
            }
            for (int i = 0; i <= max; ++i)
            {
                while (countArray[i] >= 0)
                {
                    finalSortedArray[j] = i * 1;
                    if (decimalArray[i].Decimals.Count > 0)
                    {
                        finalSortedArray[j] += (float)(decimalArray[i].Decimals.First()*0.01);
                        decimalArray[i].Decimals.RemoveAt(0);
                    }
                    ++j;
                    --countArray[i];
                }
            }
            return finalSortedArray;
        }
        //private float[] SortArrayByDecimals(float[]sortedArray)
        //{
        //    for(int i=0; i<sortedArray.Length-1; ++i)
        //    {
        //        int integerPart = (int)sortedArray[i];
        //        int startIdx = i;
        //        while ((int)sortedArray[i] == (int)sortedArray[i + 1])
        //        {
        //            ++i;
        //        }
        //        if (startIdx - i > 0)
        //        {
        //            //Node[] newArray = new Node[startIdx - i];
        //            float[] decimalArray = new float[startIdx - i];
        //            for(int j=0; j< decimalArray.Length; ++j)
        //            {
        //                var decPlaces = Utils.GetDecimals(sortedArray[startIdx+j]);
        //                decimalArray[j] = decPlaces;
        //            }
        //            //Now sort these nodes (only decimal part) by count sort
        //            float[] sortedDecimals=SortArrayByNegative(decimalArray);
        //            int k = 0;
        //            for(int j=startIdx; j<i; ++j, ++k)
        //            {
        //                sortedArray[j] = integerPart + sortedDecimals[k];
        //            }
        //        }
                
        //    }
        //    return sortedArray;

        //}
        public override float[] SortNumbers()
        {
            var sortedArray=SortArray(arrayToBeSorted);
            return sortedArray; 
        }
    }
}
