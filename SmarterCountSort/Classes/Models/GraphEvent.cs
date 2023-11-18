using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    public class GraphEvent
    {
        public GraphEvent(string tag, double timeTaken, int noOfValues) 
        { 
            Tag = tag;
            TimeTaken = timeTaken;
            NoOfValues = noOfValues;
        }
        public string Tag { get; } // readonly
        public double TimeTaken { get; }// readonly
        public int NoOfValues { get; }// readonly
    }
}
