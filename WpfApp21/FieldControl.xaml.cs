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

namespace WpfApp21 {
    /// <summary>
    /// Interaction logic for FieldControl.xaml
    /// </summary>
    public partial class FieldControl : UserControl {
        #region BackgroundPath Dependency Property
        public string BackgroundPath {
            get {
                return (string)GetValue(BackgroundPathProperty);
            }
            set {
                SetValue(BackgroundPathProperty, value);
            }
        }

        public static readonly DependencyProperty BackgroundPathProperty =
            DependencyProperty.Register("BackgroundPath", typeof(string), typeof(FieldControl), new PropertyMetadata(null));

        #endregion
        public FieldControl() {
            InitializeComponent();
        }
    }
}
