using AdvancedAlgo_Assignment1.Classes.Models;
using AdvancedAlgo_Assignment1.Classes.ViewModel;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Mvvm;
using DevExpress.XtraCharts;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AdvancedAlgo_Assignment1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        MainViewModel mainVM;
        public MainWindow()
        {
            this.InitializeComponent();
            mainVM = (MainViewModel)LayoutRoot.DataContext;
            mainVM.SampleEvent += MainVM_SampleEvent;
        }

        private void MainVM_SampleEvent(object sender, Classes.Models.GraphEvent e)
        {
            ChartViewModel chartVM = (ChartViewModel)chart.DataContext;
            switch (e.Tag)
            {
                case "countSort":
                    chartVM.UpdateCountDataPoints(new DataPoint((int)e.TimeTaken, e.NoOfValues));
                    break;
                case "mergeSort":
                    chartVM.UpdateMergeSortDataPoints(new DataPoint((int)e.TimeTaken, e.NoOfValues));
                    break;
                case "smartCountSort":
                    chartVM.UpdateSmartSortDataPoints(new DataPoint((int)e.TimeTaken, e.NoOfValues));
                    break;
                case "bubbleSort":
                    chartVM.UpdateBubbleDataPoints(new DataPoint((int)e.TimeTaken, e.NoOfValues));
                    break;
            }
            //Series series1 = chart.Series["f"];
            //chart.Series[0].

            //   ((DataSourceAdapter)chart.Series[0].da).DataSource = data;
        }

        private void Button_ClickClearPlot(object sender, RoutedEventArgs e)
        {
            ChartViewModel chartVM = (ChartViewModel)chart.DataContext;
            chartVM.BubbleDataPoints.Clear();
            chartVM.CountDataPoints.Clear();
            chartVM.MergeSortDataPoints.Clear();
            chartVM.SmartSortDataPoints.Clear();
        }
    }
    public class DataPoint
    {
        public int TotalValues { get; set; }
        public int Ticks { get; set; }
        
        public DataPoint(int ticks, int totalValues)
        {
            Ticks = ticks;
            TotalValues = totalValues;
        }
    }
    public class ChartViewModel : ViewModelBase
    {
        public void UpdateBubbleDataPoints(DataPoint dpt)
        {
            BubbleDataPoints.Add(dpt);
            BubbleDataPoints = bubbleDataPoints;
        }
        public void UpdateCountDataPoints(DataPoint dpt)
        {
            CountDataPoints.Add(dpt);
            CountDataPoints = countDataPoints;
           
        }
        public void UpdateSmartSortDataPoints(DataPoint dpt)
        {
            SmartSortDataPoints.Add(dpt);
            SmartSortDataPoints = smartSortDataPoints;
        }
        public void UpdateMergeSortDataPoints(DataPoint dpt)
        {
            MergeSortDataPoints.Add(dpt);
            MergeSortDataPoints = mergeSortDataPoints;
        }
        private ObservableCollection<DataPoint> countDataPoints     = new ObservableCollection<DataPoint>();
        private ObservableCollection<DataPoint> bubbleDataPoints    = new ObservableCollection<DataPoint>();
        private ObservableCollection<DataPoint> smartSortDataPoints = new ObservableCollection<DataPoint>();
        private ObservableCollection<DataPoint> mergeSortDataPoints = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> BubbleDataPoints
        {
            get
            {
                return bubbleDataPoints;
            }
            set
            {
                bubbleDataPoints = value;
            }
        }
        public ObservableCollection<DataPoint> CountDataPoints
        {
            get
            {
                return countDataPoints;
            }
            set
            {
                countDataPoints = value;
            }
        }
        public ObservableCollection<DataPoint> SmartSortDataPoints
        {
            get
            {
                return smartSortDataPoints;
            }
            set
            {
                smartSortDataPoints = value;
            }
        }
        public ObservableCollection<DataPoint> MergeSortDataPoints
        {
            get
            {
                return mergeSortDataPoints;
            }
            set
            {
                mergeSortDataPoints = value;
            }
        }
    }
}
