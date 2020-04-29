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
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Editors;

namespace WpfApp19 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = Vm.Create();
        }
    }

    [POCOViewModel]
    public class Vm {
        public virtual bool TickCheckBox { get; set; } = false;
        public virtual EditMode EditMode { get; set; } = EditMode.InplaceInactive;

        public static Vm Create() => ViewModelSource.Create(() => new Vm());

        protected void OnTickCheckBoxChanged() {
            if (this.TickCheckBox) {
                this.EditMode = EditMode.Standalone;
            } else {
                this.EditMode = EditMode.InplaceInactive;
            }
        }
    }
}
