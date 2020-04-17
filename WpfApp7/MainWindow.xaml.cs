using System.ComponentModel;
using System.Windows;

namespace WpfApp7 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private OrganizationAddWindowModel _viewModel;

        public MainWindow() {
            InitializeComponent();
            _viewModel = new OrganizationAddWindowModel();
            DataContext = _viewModel;
        }

        private void ViewOrganizationName_OnClick(object sender, RoutedEventArgs e) {
            MessageBox.Show($"OrganizationName: {this._viewModel.OrganizationName}");
        }
    }

    public class PullingOrganization {
        public string Name { get; set; }
        public string Logo { get; set; }
    }

    public class OrganizationAddWindowModel : BaseViewModel {
        private PullingOrganization organization;

        public string OrganizationName {
            get { return organization.Name; }
            set {
                if (value != organization.Name) {
                    organization.Name = value;
                    OnPropertyChange("OrganizationName");
                }
            }
        }
        public string OrganizationLogo {
            get { return organization.Logo; }
            set {
                if (value != organization.Logo) {
                    organization.Logo = value;
                    OnPropertyChange("OrganizationLogo");
                }
            }
        }

        public PullingOrganization Organization {
            get { return this.organization; }
        }

        public OrganizationAddWindowModel() {
            WindowTitle = "Truckpulling - Nieuwe organisatie";
            organization = new PullingOrganization();
        }
    }

    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string windowTitle;
        public string WindowTitle {
            get { return windowTitle; }
            set {
                if (windowTitle != value) {
                    windowTitle = value;
                    OnPropertyChange("WindowTitle");
                }
            }
        }

    }
}
