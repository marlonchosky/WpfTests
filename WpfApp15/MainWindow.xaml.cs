using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            sp.Add(new PeriodicSpareParts { ID = 1, SubjectName = "Oil Filter", IsSelected = false });
            sp.Add(new PeriodicSpareParts { ID = 2, SubjectName = "Air Filter", IsSelected = false });
            sp.Add(new PeriodicSpareParts { ID = 3, SubjectName = "Gas Filter", IsSelected = false });
            sp.Add(new PeriodicSpareParts { ID = 4, SubjectName = "Another", IsSelected = false });

            CheckList.ItemsSource = sp;
            CheckList.DisplayMemberPath = "SubjectName";
            CheckList.ValueMemberPath = "ID";

            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            var listOfPeriodicSparePartsIDsToCheck = new List<int> {2, 3};

            foreach (PeriodicSpareParts item in this.CheckList.ItemsSource) {
                if (listOfPeriodicSparePartsIDsToCheck.Any(x => x == item.ID))
                    item.IsSelected = true;
            }
        }

        private void CheckList_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e) {
            MessageBox.Show($"e.IsSelected: {e.IsSelected}");
        }
    }

    public class PeriodicSpareParts : INotifyPropertyChanged {
        public int ID { get; set; }
        public string SubjectName { get; set; }

        private bool isSelected;
        public bool IsSelected { 
            get => this.isSelected;
            set {
                this.isSelected = value;
                this.OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
