using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _ocrRealTime.Function;
using System.Threading;


namespace _ocrRealTime {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();

            _SetStartupLocation();
            _BringUCtoFront(0);

            this.DataContext = myGlobal.testinfo;
        }


        private void Window_Unloaded(object sender, RoutedEventArgs e) {
            myGlobal.maskwindow.Close();
        }

        private void Window_LocationChanged(object sender, EventArgs e) {
            myGlobal.maskwindow.Top = this.Top + 161;
            myGlobal.maskwindow.Left = this.Left + 7;
        }

        private void Window_StateChanged(object sender, EventArgs e) {
            if (this.WindowState == WindowState.Minimized) {
                if (myGlobal.maskwindow != null) {
                    if (!myGlobal.isVisibleMaskWindow) myGlobal.maskwindow.Visibility = Visibility.Collapsed;
                    myGlobal.maskwindow.WindowState = WindowState.Minimized;
                }
            }
            if (this.WindowState == WindowState.Normal) {
                if (myGlobal.maskwindow != null) {
                    if (!myGlobal.isVisibleMaskWindow) myGlobal.maskwindow.Visibility = Visibility.Collapsed;
                    myGlobal.maskwindow.WindowState = WindowState.Normal;
                }
            }
        }

        private void Window_Deactivated(object sender, EventArgs e) {
            if (myGlobal.isDrawingRectangle == false) {
                myGlobal.maskwindow.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Activated(object sender, EventArgs e) {
            myGlobal.maskwindow.Visibility = Visibility.Visible;
        }
    }

}
