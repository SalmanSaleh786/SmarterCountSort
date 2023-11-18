using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    internal class BubbleSort : NumberSorter
    {
        public BubbleSort(float[] arr) : base(arr)
        {

        }
        public override float[] SortNumbers()
        {
            for(int i=0; i<arrayToBeSorted.Length; ++i)
            {
                for(int j=0; j<arrayToBeSorted.Length; ++j)
                {
                    if (arrayToBeSorted[i] < arrayToBeSorted[j])
                    {
                        float temp = arrayToBeSorted[j];
                        arrayToBeSorted[j] = arrayToBeSorted[i];
                        arrayToBeSorted[i] = temp;
                    }
                }
            }
            return arrayToBeSorted;
        }
    }
}
