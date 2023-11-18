using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    public class GraphEventPublisher
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void GraphEventHandler(object sender, GraphEvent e);

        // Declare the event.
        public event GraphEventHandler SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseSampleEvent()
        {
            // Raise the event in a thread-safe manner using the ?. operator.
            SampleEvent?.Invoke(this, new GraphEvent("0", 0, 0));
        }
    }
}
