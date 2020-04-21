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

namespace WpfApp10 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var vm = new TestViewModel();
            this.DataContext = vm;
            //throw new Exception("Test2 Exception");
        }

        private void Validation_OnError(object sender, ValidationErrorEventArgs e) {
            e.Handled = true;
            throw new Exception("abc");
            
            throw e.Error.Exception;
        }
    }

    public class TestViewModel {
        private string testProp;
        public string TestProp {
            get => testProp;
            set {
                throw new Exception("Test Exception");

                testProp = value;
                
                // RAISE EXCEPTION IN PROPERTY SETTER
            }
        }
    }
}
