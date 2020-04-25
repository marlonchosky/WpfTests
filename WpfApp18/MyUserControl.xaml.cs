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

namespace WpfApp18 {
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl {
        public MyUserControl() {
            InitializeComponent();
        }

        public static readonly DependencyProperty CaretColorProperty =
            DependencyProperty.Register
            (
                "CaretColor",
                typeof(Color),
                typeof(MyUserControl),
                new FrameworkPropertyMetadata(Colors.Lime, OnCaretColorChanged)
            );

        private static void OnCaretColorChanged(DependencyObject myUserControl,
            DependencyPropertyChangedEventArgs eventArgs) {
            var control = (MyUserControl)myUserControl;
            control.CaretColor = (Color)eventArgs.NewValue;
        }

        public Color CaretColor {
            get { return (Color)GetValue(CaretColorProperty); }
            set { SetValue(CaretColorProperty, value); }
        }
    }


}
