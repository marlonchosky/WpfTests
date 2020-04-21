using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp11 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Update_OnClick(object sender, RoutedEventArgs e) {
            this.DataGrid1.ItemsSource = null;
            this.DataGrid1.ItemsSource = ContactRepository.GetAllContact();
        }

        private void UpdateObservable_OnClick(object sender, RoutedEventArgs e) {
            this.DataGrid1.ItemsSource = ContactRepository.GetAllContactObservable();
        }
    }

    public class Contact {
        public string Name { get; set; }
    }

    public static class ContactRepository {
        private static int i = 1;
        private static IList<Contact> contacts = new List<Contact> {
            new Contact { Name = "Contact#1 Edit number 1"},
        };

        public static IList<Contact> GetAllContact() {
            var contact1 = contacts[0];
            contact1.Name = contact1.Name.Replace($"Edit number {i}", $"Edit number {++i}");
            return contacts;
        }

        public static IList<Contact> GetAllContactObservable() {
            var contact1 = contacts[0];
            contact1.Name = contact1.Name.Replace($"Edit number {i}", $"Edit number {++i}");

            return new ObservableCollection<Contact>(contacts);
        }
    }
}
