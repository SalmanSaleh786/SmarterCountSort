using AdvancedAlgo_Assignment1.Classes.HelperClasses;
using AdvancedAlgo_Assignment1.Classes.Models;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void GraphEventHandler(object sender, GraphEvent e);

        // Declare the event.
        public event GraphEventHandler SampleEvent;

        private DispatcherQueue dispatcherQueue;

        private bool negativeNums = false;
        public bool NegativeNums
        {
            get
            {
                return negativeNums;
            }
            set
            {
                negativeNums = value;
                RaisePropertyChange(nameof(NegativeNums));
            }
        }
        private bool floatingNums = false;
        public bool FloatingNums
        {
            get
            {
                return floatingNums;
            }
            set
            {
                floatingNums = value;
                RaisePropertyChange(nameof(FloatingNums));
            }
        }

        private bool sortedBoolean = false;
        public bool SortedBoolean
        {
            get
            {
                return sortedBoolean;
            }
            set
            {
                sortedBoolean = value;
                RaisePropertyChange(nameof(SortedBoolean));
            }
        }
        private bool unsortedBoolean = true;
        public bool UnsortedBoolean
        {
            get
            {
                return unsortedBoolean;
            }
            set
            {
                unsortedBoolean = value;
                RaisePropertyChange(nameof(UnsortedBoolean));
            }
        }
        private string _content;
        public String MsgContent
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                RaisePropertyChange("MsgContent");
            }
        }
        private string _userCount;
        public String UserCount
        {
            get
            {
                return _userCount;
            }
            set
            {
                _userCount = value;
                RaisePropertyChange("UserCount");
            }
        }
        private RelayCommand _generateListCommand;
        public RelayCommand GenerateListCommand
        {
            get
            {
                if (_generateListCommand == null)
                {
                    _generateListCommand = new RelayCommand(GenerateNumber, CanCmdExec);
                }
                return _generateListCommand;
            }
            set
            {
                _generateListCommand = value;
            }
        }

        public MainViewModel()
        {
            dispatcherQueue = DispatcherQueue.GetForCurrentThread();
        }
        private bool CanCmdExec(object obj)
        {
            if (obj == null)
                return false;
            RadioButtons choiceRadioButtons = (RadioButtons)obj;
            bool valid = choiceRadioButtons.Items
                         .OfType<RadioButton>()
                         .Where(radioButton => radioButton != null
                         && (bool)radioButton.IsChecked)
                         .ToList().Count > 0;
            return valid;
        }
        public async void GenerateNumber(object radioButtons)
        {
            try
            {
                int count = int.Parse(UserCount);

                RadioButtons choiceRadioButtons = (RadioButtons)radioButtons;

                MsgContent = "Please wait!";
                NumberGenerator numberGenerator = new NumberGenerator();
                NumbersConfig.countNums = count;
                NumbersConfig.negativeNums = negativeNums;
                NumbersConfig.floatingNums = floatingNums;
                foreach (RadioButton radioButton in choiceRadioButtons.Items)
                {
                    if (radioButton.Tag.ToString() == "sorted" && (bool)radioButton.IsChecked)
                    {
                        await numberGenerator.GenerateSortedNumbers();
                    }
                    else if (radioButton.Tag.ToString() == "unsorted" && (bool)radioButton.IsChecked)
                    {
                        await numberGenerator.GenerateUnsortedNumbers();
                    }
                }
                MsgContent = "Task completed!";
            }
            catch (Exception ex)
            {
                MsgContent = ex.Message.ToString();
            }
        }
        public void CallUpdater()
        {
            GenerateListCommand.RaiseCanExecuteChanged();
            SortCommand.RaiseCanExecuteChanged();
        }
        private RelayCommand _radioButtonCommand;
        public RelayCommand RadioButtonCommand
        {
            get
            {
                if (_radioButtonCommand == null)
                {
                    _radioButtonCommand = new RelayCommand(parameter => CallUpdater());
                }
                return _radioButtonCommand;
            }
            set
            {
                _radioButtonCommand = value;
            }
        }
        private RelayCommand _radioButtonSortingCommand;
        public RelayCommand RadioButtonSortingCommand
        {
            get
            {
                if (_radioButtonSortingCommand == null)
                {
                    _radioButtonSortingCommand = new RelayCommand(parameter => CallUpdater());
                }
                return _radioButtonSortingCommand;
            }
            set
            {
                _radioButtonSortingCommand = value;
            }
        }


        private RelayCommand _sortCommand;
        public RelayCommand SortCommand
        {
            get
            {
                if (_sortCommand == null)
                {
                    _sortCommand = new RelayCommand(SortNumber, CanCmdExec);
                }
                return _sortCommand;
            }
            set
            {
                _sortCommand = value;
            }
        }
        public void SortNumber(object radioButtons)
        {
            MsgContent = "Please wait!";

            RadioButtons choiceRadioButtons = (RadioButtons)radioButtons;
            NumberSorter numbersSorter;
            string tag = "";
            TimeSpan timeSpan = TimeSpan.Zero;
            dispatcherQueue.TryEnqueue(() =>
            {
                var selectedRadiobutton = (RadioButton)choiceRadioButtons.SelectedItem;
                tag = selectedRadiobutton.Tag.ToString();
            });
            Task.Run(() =>
            {
                try
                {
                    List<float> numbers = new List<float>();
                    string path = AppDomain.CurrentDomain.BaseDirectory + "\\Data.txt";

                    if (SortedBoolean)
                    {
                        path = AppDomain.CurrentDomain.BaseDirectory + "\\SortedData.txt";

                    }
                    string[] lines = System.IO.File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        numbers.Add(float.Parse(line));
                    }
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    switch (tag)
                    {
                        case "countSort":
                            if (negativeNums || floatingNums)
                            {
                                throw new Exception("Count Sort cannot sort negative/floating numbers!");
                            }
                            numbersSorter = new CountSort(numbers.ToArray());
                            numbersSorter.SortNumbers();
                            break;
                        case "mergeSort":
                            numbersSorter = new MergeSort(numbers.ToArray());
                            numbersSorter.SortNumbers();
                            break;
                        case "smartCountSort":
                            numbersSorter = new SmartCountSort(numbers.ToArray());
                            numbersSorter.SortNumbers();
                            break;
                        case "bubbleSort":
                            numbersSorter = new BubbleSort(numbers.ToArray());
                            numbersSorter.SortNumbers();
                            break;
                        default:
                            break;
                    }
                    stopwatch.Stop();
                    var timeUsed = TimeOnly.FromTimeSpan(stopwatch.Elapsed);
                    double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
                    dispatcherQueue.TryEnqueue(() =>
                    {
                        MsgContent = string.Format("Total milliseconds consumed are {0} by {1}", elapsedMilliseconds, tag);
                        UpdatePlot(tag, elapsedMilliseconds, numbers.Count);
                    });


                }
                catch (Exception ex)
                {
                    dispatcherQueue.TryEnqueue(() =>
                    {
                        MsgContent = ex.Message.ToString();
                    });
                }
            });
        }

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected void RaiseSampleEvent()
        {
            // Raise the event in a thread-safe manner using the ?. operator.
            SampleEvent?.Invoke(this, new GraphEvent("0", 0, 0));
        }
        private void UpdatePlot(string tag, double timeTaken, int noOfValues)
        {
            SampleEvent?.Invoke(this, new GraphEvent(tag, timeTaken, noOfValues));
        }
    }
}
