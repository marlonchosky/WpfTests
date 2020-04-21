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

namespace WpfApp12 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OpenWindow_OnClick(object sender, RoutedEventArgs e) {
            var windowToOpen = new Window1();
            windowToOpen.Closing += (o, args) => {
            };
            windowToOpen.AfterClosingEvent += (o, s) => {
                this.TextBlock1.Text = s;
            };
            windowToOpen.Show();
        }
    }
}
