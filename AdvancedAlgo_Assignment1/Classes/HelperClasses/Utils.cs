using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.HelperClasses
{
    internal class Utils
    {
        internal static void DisplayMessage(string message)
        {
            var dispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
            dispatcherQueue.TryEnqueue(async () => 
            {
                ContentDialog dialogMsg = new ContentDialog()
                {

                    Title = "Information",
                    Content = message,
                    CloseButtonText = "Ok"
                };
                await dialogMsg.ShowAsync();
            });
        }
        internal static int GetDecimals(float number)
        {
            return (int)(((decimal)number % 1) * 100);
        }
        internal static void Populate<T>(T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = value;
            }
        }
    }
}
