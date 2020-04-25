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

namespace WpfApp16 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void GetPosition_OnClick(object sender, RoutedEventArgs e) {
            Point posicion = Mouse.GetPosition(Application.Current.MainWindow);
            TextPointer posAhora = richTextBox1.GetPositionFromPoint(posicion, false);
            if (posAhora != null) {
                check.IsChecked = true;
            } else {
                check.IsChecked = false;
            }
        }
    }
}
