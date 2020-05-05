using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp26 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly ViewModel vm;

        public MainWindow() {
            InitializeComponent();

            // Setting the Window's DataContext to a object of the ViewModel class.
            this.DataContext = this.vm = new ViewModel();
        }

        private void ModuleSelected_OnClick(object sender, RoutedEventArgs e) {
            // The Source property of the RoutedEventArgs gets the Element that fires the event (in this case, the button).
            var clickedButton = (Button) e.Source;
            this.vm.CurretModuleName = clickedButton.Content.ToString();

            // Getting the Tag property of the button.
            var tag = clickedButton.Tag.ToString();

            // Performing the navigation.
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

    // The class implementents the INotifyPropertyChanged interface, that is used 
    // by the WPF framework to update binding.
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
