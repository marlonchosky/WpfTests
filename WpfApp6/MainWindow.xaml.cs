using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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

namespace WpfApp6 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            LoggingData.UserName = "Zelda";

            var data = new List<CustomVm> {
                new CustomVm { JobName = "Job #1", Username = "Link"},
                new CustomVm { JobName = "Job #2", Username = "Zelda"},
            };
            this.DataContext = data;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Logic");
        }
    }

    public class CustomVm {
        public string JobName { get; set; }
        public string Username { get; set; }
    }

    [ValueConversion(typeof(string), typeof(bool))]
    public class UsernameToEnabledConverter : IValueConverter {
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var username = value.ToString();
            if (username == LoggingData.UserName) {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    public static class LoggingData {
        public static string UserName { get; set; }
    }
}
