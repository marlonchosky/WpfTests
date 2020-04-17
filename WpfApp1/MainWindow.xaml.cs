﻿using System;
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

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var items = ObtenerItems();
            this.DataContext = items;
        }

        private IList<Car> ObtenerItems() => new List<Car> {
            new Car {PetName = "Ninja"},
            new Car {PetName = "Destroyer"},
        };
    }

    public class Car {
        public string PetName { get; set; }
    }
}
