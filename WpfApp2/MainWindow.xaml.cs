using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private const bool ENABLED = true;
        private const bool DISABLED_BY_USER = false;

        public MainWindow() {
            InitializeComponent();

            this.InitializeButtons();
            this.TxtRound.Text = this.currentRound.ToString();
        }

        private int currentRound = 0;
        private int numberOfDisabledButtonsInCurrentRound = 0;
        private const int quantityOfDisabledButtonsToEndRound = 3;
        private readonly IList<Button> buttons = new List<Button>(20);

        private void InitializeButtons() {
            for (var i = 0; i < 20; i++) {
                var button = new Button {
                    Content = $"Button #{i + 1}",
                    Tag = ENABLED, // The tag indicates if the button is enabled or not
                    Margin = new Thickness(5)
                };
                button.Click += ButtonOnClick;
                this.RootLayout.Children.Add(button);
                this.buttons.Add(button);
            }

            #region Internal methods
            void ButtonOnClick(object sender, RoutedEventArgs e) {
                if (this.numberOfDisabledButtonsInCurrentRound == 0) {
                    this.currentRound++;
                    this.TxtRound.Text = this.currentRound.ToString();
                }

                this.numberOfDisabledButtonsInCurrentRound++;

                var btn = (Button) e.Source;
                btn.IsEnabled = false;
                btn.Tag = DISABLED_BY_USER;

                if (this.numberOfDisabledButtonsInCurrentRound == quantityOfDisabledButtonsToEndRound) {
                    foreach (var b in this.buttons) {
                        b.IsEnabled = false;
                    }

                    this.BtnAnother.IsEnabled = true;
                }
            } 
            #endregion
        }

        private void AnotherButton_OnClick(object sender, RoutedEventArgs e) {
            EnableOnlyButtonsNotDisabledByUser();

            this.BtnAnother.IsEnabled = false;
            this.numberOfDisabledButtonsInCurrentRound = 0;
            #region Internal methods
            void EnableOnlyButtonsNotDisabledByUser() {
                foreach (var btn in this.buttons.Where(x => (bool)x.Tag != DISABLED_BY_USER)) {
                    btn.IsEnabled = true;
                }
            } 
            #endregion
        }
    }
}
