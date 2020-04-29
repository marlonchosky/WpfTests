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
using System.Windows.Shapes;

namespace WpfApp20 {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            var element = this.GetElementInGridPosition(1, 1);
            if (element is Button)
                MessageBox.Show($"The element in 1,1 is a button.");

            element = this.GetElementInGridPosition(2, 1);
            if (element is Button)
                MessageBox.Show($"The element in 2,1 is a button.");
            else
                MessageBox.Show($"The element in 2,1 isn't a button, it's a {element.GetType().Name}.");
        }

        private UIElement GetElementInGridPosition(int column, int row) {
            foreach (UIElement element in this.RootGrid.Children) {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }

            return null;
        }
    }
}
