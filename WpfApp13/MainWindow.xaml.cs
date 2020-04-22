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

namespace WpfApp13 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = new List<Car> {
                new Car { PetName = "Zelda", MaxVelocity = 99.2M},
                new Car { PetName = "Link", MaxVelocity = 99.2M},
                new Car { PetName = "Mario", MaxVelocity = 99.2M},
                new Car { PetName = "Peach", MaxVelocity = 99.2M},
            };
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            var selectedCell = DataGrid1.SelectedCells[0];
        }
    }

    public class Car {
        public string PetName { get; set; }
        public decimal MaxVelocity { get; set; }
    }
}
