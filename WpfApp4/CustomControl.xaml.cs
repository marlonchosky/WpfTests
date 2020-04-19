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

namespace WpfApp4 {
    /// <summary>
    /// Interaction logic for CustomControl.xaml
    /// </summary>
    public partial class CustomControl : UserControl {
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register(
            "FirstName",
            typeof(string),
            typeof(CustomControl),
            new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string FirstName {
            get {
                return (string)GetValue(FirstNameProperty);
            }
            set {
                SetValue(FirstNameProperty, value);
            }
        }

        public CustomControl() {
            InitializeComponent();
        }
    }
}
