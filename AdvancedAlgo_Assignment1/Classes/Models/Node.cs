using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    internal class Node
    {
        
        private int integer=-1;
        private int decimals=0;

        public int Integer
        {
            get => integer; 
            set => integer = value;
        }
        public int Decimals
        {
            get => decimals;
            set => decimals = value;
        }

        public Node(int integer, int decimals)
        {
            Integer = integer;
            Decimals = decimals;
        }
    }
}
