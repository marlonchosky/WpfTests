using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WpfApp12 {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        public event EventHandler<string> AfterClosingEvent;

        private void Window1_OnClosing(object sender, CancelEventArgs e) {
            // Logic for your database update...

            this.AfterClosingEvent?.Invoke(this, this.TextBox1.Text);
        }
    }
}
