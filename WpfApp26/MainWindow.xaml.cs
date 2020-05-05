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

namespace WpfApp26 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly ViewModel vm;

        public MainWindow() {
            InitializeComponent();

            this.DataContext = this.vm = new ViewModel();
        }

        private void ModuleSelected_OnClick(object sender, RoutedEventArgs e) {
            var clickedButton = (Button) e.Source;
            this.vm.CurretModuleName = clickedButton.Content.ToString();

            var tag = clickedButton.Tag.ToString();
            switch (tag) {
                case "ToDoListModule":
                    NavigateToModule(new UcToDoListModule());
                    break;
                case "MyAgendaModule":
                    NavigateToModule(new UcMyAgendaModule());
                    break;
            }

            #region Internal methods
            void NavigateToModule(UserControl uc) {
                this.GbCurrentModule.Content = uc;
            } 
            #endregion
        }
    }

    public class ViewModel : INotifyPropertyChanged {
        private string curretModuleName;
        public string CurretModuleName {
            get => this.curretModuleName;
            set {
                this.curretModuleName = value;
                this.OnPropertyChanged();
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
