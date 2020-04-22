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

namespace WpfApp15 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            List<PeriodicSpareParts> sp = new List<PeriodicSpareParts>();
            sp.Add(new PeriodicSpareParts { ID = 1, SubjectName = "Oil Filter" });
            sp.Add(new PeriodicSpareParts { ID = 2, SubjectName = "Air Filter" });
            sp.Add(new PeriodicSpareParts { ID = 3, SubjectName = "Gas Filter" });

            CheckList.ItemsSource = sp;
            CheckList.DisplayMemberPath = "SubjectName";
            CheckList.ValueMemberPath = "ID";
        }

        private void CheckList_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e) {

        }
    }

    public class PeriodicSpareParts {
        public int ID { get; set; }
        public string SubjectName { get; set; }
    }
}
