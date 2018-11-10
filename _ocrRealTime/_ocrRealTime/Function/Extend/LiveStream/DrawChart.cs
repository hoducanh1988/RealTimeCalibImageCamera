using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _ocrRealTime.ucControl {
    /// <summary>
    /// Interaction logic for ucLiveStream.xaml
    /// </summary>
    public partial class ucLiveStream : UserControl {

        public double MinValue {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(ucLiveStream), new PropertyMetadata(default(double)));


        public string ChartTitle {
            get { return (string)GetValue(ChartTitleProperty); }
            set { SetValue(ChartTitleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartTitleProperty =
            DependencyProperty.Register("ChartTitle", typeof(string), typeof(ucLiveStream), new PropertyMetadata(default(string)));


        
        public double x = 0, y = 0;
        public double minY = double.MaxValue;
        public double maxY = double.MinValue;

        public ObservableCollection<ChartData> chartData { get; set; }
        int range = 100;


        public void AddChartData(double y) {
            chartData.Add(new ChartData() { Value1 = x, Value2 = y });
            MinValue = x < range ? 0 : x - range;
            x++;
        }

        //public void Run() {
        //    int count = 0;
        //    Dispatcher.Invoke(new Action(() => { chartData.Clear(); }));

        //    while (true) {
        //        count++;
        //        //serialPort1.Write("a");
        //        //rx_str = serialPort1.ReadTo("b");
        //        //rx_str_copy = rx_str;

        //        //x = a;
        //        //y = Double.Parse(rx_str_copy, CultureInfo.InvariantCulture);

        //        //a++;

        //        Dispatcher.Invoke(new Action(delegate
        //        {

        //            if (count % 10 == 0) {
        //                chartData.Add(new ChartData() {
        //                    Value1 = x,
        //                    Value2 = 0,
        //                    //Value2 = y
        //                });
        //            }
        //            else {
        //                chartData.Add(new ChartData() {
        //                    Value1 = x,
        //                    Value2 = 1,
        //                    //Value2 = y
        //                });
        //            }

        //            MinValue = x < range ? 0 : x - range;
        //            x++;
        //        }));

        //        Thread.Sleep(500);
        //    }
        //}

    }

    public class ChartData : INotifyPropertyChanged {
        double _Value1;
        double _Value2;


        public double Value1 {
            get {
                return _Value1;
            }
            set {
                _Value1 = value;
                OnPropertyChanged("Value1");
            }
        }

        public double Value2 {
            get {
                return _Value2;
            }
            set {
                _Value2 = value;
                OnPropertyChanged("Value2");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new
         PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
