using AdvancedAlgo_Assignment1.Classes.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    internal class CountSort : NumberSorter
    {
        int[] countArray;
        int max = 0;

        public CountSort(float[] arr) : base(arr)
        {

        }
        public override float[] SortNumbers()
        {
            foreach (int num in arrayToBeSorted)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            countArray = new int[max+1];
            Utils.Populate(countArray, -1);
            for (int i = 0; i < arrayToBeSorted.Length; ++i)
            {
                countArray[Convert.ToInt32(arrayToBeSorted[i])] += 1;
            }
            float[] resultArray = new float[arrayToBeSorted.Length];
            int j = 0;
            for (int i = 0; i < countArray.Length; ++i)
            {
                while (countArray[i] >= 0)
                {
                    resultArray[j++] = i;
                    --countArray[i];
                }
            }


            return resultArray;
        }
        // A function to do counting sort of arr[] according to
        // the digit represented by exp.
        
    }
}
