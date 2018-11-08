﻿using System;
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

namespace _ocrRealTime.ucControl {
    /// <summary>
    /// Interaction logic for ucSetting.xaml
    /// </summary>
    public partial class ucSetting : UserControl {
        public ucSetting() {
            InitializeComponent();
            this.cbbcmptype.ItemsSource = myParameter.ListCompareType;

            this.DataContext = myGlobal.defaultsetting;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            myGlobal.defaultsetting.SaveSetting();
            MessageBox.Show("Success!", "Save Setting", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
