using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    internal class DecimalCollection
    {
        private List<int> decimals=new List<int>();
        public List<int> Decimals
        {
            get
            {
                return decimals;
            }
        }
        public void InsertionSortAdd(int number)
        {
        
            if (number < 0)
                number *= -1;
            {
                for (int i = 0; i < Decimals.Count; i++)
                {
                    if (Decimals[i] >= number)
                    {
                        Decimals.Insert(i, number);
                        return;
                    }
                }
                Decimals.Add(number);
            }
        }
    }
}
