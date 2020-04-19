using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

namespace WpfApp8 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            //var key = Key.A;                            // Key to send
            //var target = this.Txt1;    // Target element
            //var routedEvent = Keyboard.KeyDownEvent; // Event to send

            //target.RaiseEvent(
            //    new KeyEventArgs(
            //            Keyboard.PrimaryDevice,
            //            PresentationSource.FromVisual(target),
            //            0,
            //            key)
            //        { RoutedEvent=routedEvent }
            //);

            var text = "Hello";
            var key = Key.A.ToString();                            // Key to send
            var target = this.Txt1;
            var routedEvent = TextCompositionManager.TextInputEvent;

            target.RaiseEvent(
                new TextCompositionEventArgs(
                        InputManager.Current.PrimaryKeyboardDevice,
                        new TextComposition(InputManager.Current, target, key))
                    { RoutedEvent = routedEvent }
            );
        }
    }
}
