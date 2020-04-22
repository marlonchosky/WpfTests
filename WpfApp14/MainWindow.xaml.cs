using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp14 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            DataTable _dt = new DataTable("MyDataTable");
            _dt.Columns.Add("ID", typeof(int));
            _dt.Columns.Add("File", typeof(string));
            _dt.Columns.Add("Folder", typeof(string));
            _dt.Columns.Add("Status", typeof(string));
            _dt.Columns["ID"].AutoIncrement = true;
            _dt.Columns["ID"].AutoIncrementSeed = 1;
            _dt.Columns["ID"].AutoIncrementStep = 1;

            this.FilesGridView.SelectionMode = DataGridSelectionMode.Extended;
            this.FilesGridView.ItemsSource = _dt.DefaultView;
        }

        private async void Process_OnClick(object sender, RoutedEventArgs e) {
            await Task.Run(async () => {
                foreach (DataRowView row in this.FilesGridView.ItemsSource) {
                    row["Status"] = "Processing...";
                    await Task.Delay(2000);
                }
            });

        }
    }
}
