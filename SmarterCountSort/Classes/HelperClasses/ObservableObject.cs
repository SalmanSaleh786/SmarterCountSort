using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace AdvancedAlgo_Assignment1.Classes.HelperClasses
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        TaskScheduler UISyncContext = TaskScheduler.FromCurrentSynchronizationContext();
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
               
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
